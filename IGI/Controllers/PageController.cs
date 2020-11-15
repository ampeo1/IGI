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
    public class PageController : Controller
    {
        private readonly Interface.IUser users;
        public PageController(Interface.IUser users)
        {
            this.users = users;
        }
        [HttpGet]
        public IActionResult Page()
        {
            User user = users.GetUser(User.Identity.GetUserId());
            return View(user);
        }
    }
}
