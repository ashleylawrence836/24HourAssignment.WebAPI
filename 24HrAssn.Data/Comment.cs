﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public Guid Author { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset EditedUtc { get; set; }

        public virtual List<Reply> Replies { get; set; } = new List<Reply>();
        [Required]
        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }
        

    }
}
