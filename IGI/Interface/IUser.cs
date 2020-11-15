using IGI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Interface
{
    public interface IUser
    {
        IEnumerable<User> GetAllUsers { get; }
        User GetUser(string id);
    }
}
