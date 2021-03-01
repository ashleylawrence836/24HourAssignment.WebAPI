using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Data
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public Guid Author { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset EditUtc { get; set; }

        // Virtual list of comments

    }
}
