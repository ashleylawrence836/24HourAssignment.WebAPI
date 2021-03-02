using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Models
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(2000, ErrorMessage = "Sorry. I can't allow that, user")]
        public string Text { get; set; }
    }
}
