using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Models
{
    public class ReplyDetail
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name = "Reply By")]
        public Guid Author { get; set; }

        [Display(Name = "Reply")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? EditUtc { get; set; }
    }
}
