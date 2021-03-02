using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        [Display(Name = "Comment By")]
        public Guid Author { get; set; }

        [Display(Name = "Commented On")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? EditUtc { get; set; }

        public List<ReplyDetail> Replies { get; set; }
    }
}
