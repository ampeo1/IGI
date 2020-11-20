using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace IGI.Models
{
    public class EmailService: Controller
    {
        public async Task VerificationAsync(string mail, string name)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "igiLaba@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", mail));
            emailMessage.Subject = "Подтверждение почты";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "https://localhost:44343/Account/Verification?name=" + name
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("igiLaba@yandex.ru", "mgltmxqvkhctecmm");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
