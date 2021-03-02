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
        public string Text { get; set; }

        [Display(Name = "Reply By")]
        public Guid Author { get; set; }

        [ForeignKey(nameof(CommentId))]
        public int CommentId { get; set; }
        public virtual CommentDetail Comment { get; set; }
    }
}
