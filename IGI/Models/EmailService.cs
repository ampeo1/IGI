using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Microsoft.Extensions.Configuration;

namespace IGI.Models
{
    public class EmailService: Controller
    {
        IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task VerificationAsync(string mail, string name, string token)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", configuration.GetSection("Mail").Value));
            emailMessage.To.Add(new MailboxAddress("", mail));
            emailMessage.Subject = "Подтверждение почты";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = configuration.GetSection("Url").Value + name + "&token=" + token
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(configuration.GetSection("Stmp").Value, 25, false);
                await client.AuthenticateAsync(configuration.GetSection("Mail").Value, configuration.GetSection("Password").Value);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
