using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGI.Interface;
using IGI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using IGI.ViewModels;

namespace IGI.Controllers
{
    public class UsersController : Controller
    {
        private readonly Interface.IUser users;
        private UserContext context;
        private string id;
        public UsersController(Interface.IUser users, UserContext context)
        {
            this.users = users;
            this.context = context;
        }

        [HttpGet]
        public IActionResult Page(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = User.Identity.GetUserId();
            }
            this.id = id;
            PageViewModel model = new PageViewModel();
            model.user = users.GetUser(id);
            model.Publications = context.Publications.Where(publication => publication.UserId == id);
            List<Comment> comments = new List<Comment>();
            List<Comment> AllComments = context.Comments.ToList();
            foreach (Publication publication in model.Publications)
            {
                comments.AddRange(AllComments.Where(comments => comments.IdPublication == publication.Id));
            }
            model.Comments = comments;
            return View(model);
        }

        [HttpPost]
        public IActionResult NewPublication(string text, string username, string pageId)
        {
            Publication publication = new Publication { Id = Guid.NewGuid().ToString(), Text = text, UserId = pageId, UserName = username };
            context.Publications.Add(publication);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult NewComment(string text, string username, string publicationId)
        {
            Comment comment = new Comment { Id = Guid.NewGuid().ToString(), Text = text, IdPublication = publicationId, Username = username };
            context.Comments.Add(comment);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AllUsers()
        {
            return View(users.GetAllUsers);
        }
        
    }
}
