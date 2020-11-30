using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Models
{
    public class Message
    {
        public string Id { get; set; }
        [Required]
        public string AddresseeId { get; set; }
        [Required]
        public string SenderId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Username { get; set; }
        public DateTime Date { get; set; }

    }
}
