using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Models
{
    public class ReplyCreate
    {
        [Required]
        public int CommentId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Nothing to reply!")]
        [MaxLength(2000, ErrorMessage = "The amount of characters in this field is astronomical.")]
        public string Text { get; set; }
    }
}
