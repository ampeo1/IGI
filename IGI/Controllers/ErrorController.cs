using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IGI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(string code)
        {
            return View("Index", code);
        }
    }
}
