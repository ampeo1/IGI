using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IGI.Interface;
using IGI.Models;
using IGI.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IGI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        UserContext context;
        IWebHostEnvironment appEnvironment;
        IConfiguration configuration;
        IEmailService emailService;

        public AccountController(UserContext context, IWebHostEnvironment appEnvironment, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, IEmailService emailService)
        {
            this.context = context;
            this.appEnvironment = appEnvironment;
            _userManager = userManager;
            _signInManager = signInManager;
            this.configuration = configuration;
            this.emailService = emailService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                string path = null, imageName;
                Image avatar = null;
                if (model.Avatar != null)
                {
                    imageName = model.Username + "_" + DateTime.Now.ToString().Replace(' ', '_') + "_" + model.Avatar.FileName;
                    //path = "\\files\\" + imageName;
                    path = configuration.GetSection("ImagePath").Value + model.Avatar.FileName;
                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await model.Avatar.CopyToAsync(fileStream);
                    }
                    avatar = new Image { Name = imageName, Path = path };
                }
                User user = new User(model.Username, model.Email, path, model.Name, model.Surname, model.Age, model.Country);
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (avatar != null)
                    {
                        context.Files.Add(avatar);
                        context.SaveChanges();
                    }
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    SendMailVerification(user);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, true,  false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> VerificationAsync(string username, string token)
        {
            User user = context.Users.FirstOrDefault(user => user.UserName == username);
            await _userManager.ConfirmEmailAsync(user, token);

            return View();
        }

        public async void SendMailVerification(User user)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            await emailService.VerificationAsync(user.Email, user.UserName, token, configuration);
        }
    }
}
