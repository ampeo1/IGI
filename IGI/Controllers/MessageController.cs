﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGI.Models;
using IGI.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IGI.Controllers
{
    public class MessageController : Controller
    {
        UserContext context;
        public MessageController(UserContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Send(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                User user = context.Users.FirstOrDefault(user => user.Id == id);
                if (user != null)
                {
                    MessageModel model = new MessageModel();
                    model.AddresseeId = id;
                    model.AddresseeIdUsername = user.UserName;
                    IEnumerable<Message> messages = context.Messages.Where(message => (message.SenderId == id && message.AddresseeId == User.Identity.GetUserId())
                    || (message.AddresseeId == id && message.SenderId == User.Identity.GetUserId())).OrderBy(message => message.Date);
                    model.Messages = messages;
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Send(MessageModel model)
        {
            if (ModelState.IsValid)
            {
                Message message = new Message();
                message.Id = Guid.NewGuid().ToString();
                message.Date = DateTime.UtcNow;
                TimeZoneInfo belarusTZI = TimeZoneInfo.FindSystemTimeZoneById("Belarus Standard Time");
                message.Date = TimeZoneInfo.ConvertTimeFromUtc(message.Date, belarusTZI);
                message.Text = model.Text;
                message.SenderId = User.Identity.GetUserId();
                message.AddresseeId = model.AddresseeId;
                message.Username = User.Identity.Name;
                context.Messages.Add(message);
                context.SaveChanges();
                return Send(model.AddresseeId);
            }
            return NotFound();
        }
    }
}
