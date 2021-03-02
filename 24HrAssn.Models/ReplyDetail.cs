using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Models
{
    public class ReplyDetail
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        [Display(Name = "Reply By")]
        public Guid Author { get; set; }

        [Display(Name = "Reply")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? EditUtc { get; set; }

        [ForeignKey(nameof(CommentId))]
        public virtual CommentDetail Comment { get; set; }
    }
}
