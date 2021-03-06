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
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Author = _userId,
                    Text = model.Text,
                    CommentId = model.CommentId
                };
            using (var context = new ApplicationDbContext())
            {
                context.Replies.Add(entity);
                return context.SaveChanges() == 1;
            }
        }


        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                    .Replies
                    .Where(e => e.Author == _userId)
                    .Select(
                        e =>
                            new ReplyListItem
                            {
                                CommentId = e.CommentId,
                                Text = e.Text
                            });

                return query.ToArray();
            }
        }
    }
}
