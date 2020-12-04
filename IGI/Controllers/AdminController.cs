using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGI.Models;
using IGI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IGI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<User> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> UserList()
        {
            AdminViewModel model = new AdminViewModel();
            model.Users = _userManager.Users.ToList();
            model.Admins = await _userManager.GetUsersInRoleAsync("admin");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                var userRole = await _userManager.GetRolesAsync(user);
                if (userRole.Contains("admin"))
                {
                    await _userManager.RemoveFromRoleAsync(user, "admin");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "admin");
                }

                return RedirectToAction("Index", "Home");
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                await _userManager.DeleteAsync(user);
                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }
    }
}
