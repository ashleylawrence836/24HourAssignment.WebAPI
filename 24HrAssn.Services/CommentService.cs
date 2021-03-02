using _24HourAssignment.WebAPI.Data;
using _24HrAssn.Data;
using _24HrAssn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HrAssn.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    PostId = model.PostId,
                    Author = _userId,
                    Text = model.Text,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var context = new ApplicationDbContext())
            {
                context.Comments.Add(entity);
                Post post = context.Posts.FindAsync(model.PostId).Result;
                post.Comments.Add(entity);
                return context.SaveChanges() == 1;
            }

        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .Comments
                    .Where(e => e.Author == _userId)
                    .Select(
                        e =>
                            new CommentListItem
                            {
                                PostId = e.PostId,
                                Text = e.Text
                            });

                return query.ToArray();

            }
        }

        public List<CommentDetail> GetCommentsByPostID(int postId)
        {
            using (var context = new ApplicationDbContext())
            {
                var post = context.Posts.Single
                    (p => p.PostId == postId);

                List<CommentDetail> comments = new List<CommentDetail>();

                foreach (Comment comment in post.Comments)
                {
                    comments.Add(new CommentDetail
                    {
                        CommentId = comment.CommentId,
                        Text = comment.Text,
                        Author = comment.Author,
                        CreatedUtc = comment.CreatedUtc,
                    });
                }

                return comments;
            }
        }
    }
}
