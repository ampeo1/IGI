using IGI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<User> Admins { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
