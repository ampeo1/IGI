using IGI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.ViewModels
{
    public class MessageModel
    {
        [Required]
        public string Text { get; set; }
        public string AddresseeIdUsername { get; set; }
        public string AddresseeId { get; set; }

        public IEnumerable<Message> Messages { get; set; }
    }
}
