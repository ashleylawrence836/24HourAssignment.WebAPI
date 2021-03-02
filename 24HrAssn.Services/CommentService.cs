﻿using _24HourAssignment.WebAPI.Data;
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
                    Author = _userId,
                    Text = model.Text,
                };
            using (var context = new ApplicationDbContext())
            {
                context.Comments.Add(entity);
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
    }
}
