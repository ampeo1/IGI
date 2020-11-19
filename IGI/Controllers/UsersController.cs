using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGI.Interface;
using IGI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

namespace IGI.Controllers
{
    public class UsersController : Controller
    {
        private readonly Interface.IUser users;
        public UsersController(Interface.IUser users)
        {
            this.users = users;
        }

        [HttpGet]
        public IActionResult Page(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = User.Identity.GetUserId();
            }
            return View(users.GetUser(id));
        }

        public IActionResult AllUsers()
        {
            return View(users.GetAllUsers);
        }
    }
}
