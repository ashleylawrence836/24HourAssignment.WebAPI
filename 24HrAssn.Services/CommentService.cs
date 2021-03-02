using _24HourAssignment.WebAPI.Data;
using _24HrAssn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Services
{
    public class CommentService
    {
        public class PostService
        {
            private readonly Guid _userId;

            public PostService(Guid userId)
            {
                _userId = userId;
            }


            public bool CreatePost(CommentCreate model)
            {
                var entity =
                    new Comment()
                    {
                        Author = _userId,
                        Text = model.Content,
                    };
                using (var context = new ApplicationDbContext())
                {
                    context.Comments.Add(entity);
                    return context.SaveChanges() == 1;
                }

            }
        }
    }
}
