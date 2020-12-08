using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Models
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string message, string addressee)
        {
            await this.Clients.User(addressee).SendAsync("ReceiveMessage", message, Context.User.Identity.Name);
            await this.Clients.User(Context.UserIdentifier).SendAsync("ReceiveMessage", message, Context.User.Identity.Name);
        }
    }
}
