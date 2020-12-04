using IGI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.ViewModels
{
    public class PageViewModel
    {
        public User user { get; set; }
        public IEnumerable<Publication> Publications { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        [Required(ErrorMessage = "Не указана Фамиля")]
        public string NewText { get; set; }
        public string NewCommentText { get; set; }
        public string NewCommentUserName { get; set; }
        public string NewCommentPublicationId { get; set; }
    }
}
