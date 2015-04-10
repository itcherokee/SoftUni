using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BlogSystem.Models;

namespace BlogSystem.Web.Models
{
    public class CommentOutputData
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public static Expression<Func<Comment, CommentOutputData>> FromComment
        {
            get
            {
                return a => new CommentOutputData
                {
                    Id = a.Id,
                    Content = a.Content,
                    UserId  = a.UserId
                };
            }
        }
    }
}