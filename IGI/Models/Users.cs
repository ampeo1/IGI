using IGI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Models
{
    public class Users: IUser
    {
        private readonly UserContext context;

        public Users(UserContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAllUsers => context.Users;
        public User GetUser(string id) => context.Users.FirstOrDefault(user => user.Id == id);
    }
}
