using _24HrAssn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Data
{
    public class Reply : Comment
    {
        [Required]
        [ForeignKey(nameof(CommentId))]
        public virtual CommentDetail Comment { get; set; }
    }
}
