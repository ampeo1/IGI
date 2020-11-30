using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Models
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string message, string username)
        {
            await this.Clients.All.SendAsync("ReceiveMessage", message, username);
        }

        public string getToken(string id)
        {
            return Clients.User(id).ToString();
        }
    }
}
