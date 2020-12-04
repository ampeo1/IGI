using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace IGI.Models
{
    public class User: IdentityUser
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public string Country { get; set; }

        public User(string userName, string email, string path, string name, string surname, byte age, string country)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = "/files/noAvatar.jpg";
            }
            UserName = userName;
            Email = email;
            Path = path;
            Name = name;
            Surname = surname;
            Age = age;
            Country = country;
        }

        public User()
        {
            Path = "/files/noAvatar.jpg";
        }

        public string getToken()
        {
            return "";
        }
    }
}
