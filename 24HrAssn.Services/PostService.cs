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
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Author = _userId,
                    Title = model.Title,
                    Text = model.Text,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var context = new ApplicationDbContext())
            {
                context.Posts.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .Posts
                    .Where(e => e.Author == _userId)
                    .Select(
                        e =>
                            new PostListItem
                            {
                                PostId = e.PostId,
                                Title = e.Title,
                                Text = e.Text,
                            });

                return query.ToArray();
            }
        }


        public PostDetail GetPostByID(int postId)
        {
            using (var context = new ApplicationDbContext())
            {
                var post = context.Posts.Single
                    (p => p.PostId == postId);

                PostDetail thePost = new PostDetail
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Text = post.Text,
                    Author = post.Author,
                    CreatedUtc = post.CreatedUtc
                };

                foreach (Comment comment in post.Comments)
                {
                    thePost.Comments.Add(new CommentDetail
                    {
                        CommentId = comment.CommentId,
                        Text = comment.Text,
                        Author = comment.Author,
                        CreatedUtc = comment.CreatedUtc,
                    });
                }

                return thePost;
            }
        }
    }
}
