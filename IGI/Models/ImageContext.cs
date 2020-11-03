using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Models
{
    public class ImageContext: DbContext
    {
        public DbSet<Image> Files { get; set; }
        public ImageContext(DbContextOptions<ImageContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
