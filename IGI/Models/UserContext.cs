using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Models
{
    public class UserContext: IdentityDbContext<User>
    {
        public UserContext(DbContextOptions<UserContext> options)
            :base(options)
        {
        }
        public DbSet<Image> Files { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
