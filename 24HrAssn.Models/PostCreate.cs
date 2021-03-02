using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Models
{
    public class PostCreate
    {
        [Required]
        [MaxLength(2000, ErrorMessage = "Too long man")]
        public string Title { get; set; }

        [MaxLength(2000, ErrorMessage = "That's way too long buddy!")]
        public string Text { get; set; }
    }
}
