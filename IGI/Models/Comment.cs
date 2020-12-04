using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string IdPublication { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
    }
}
