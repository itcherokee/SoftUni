using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BlogSystem.Models;

namespace BlogSystem.Web.Models
{
    public class PostOutputData
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public static Expression<Func<Post, PostOutputData>> FromPost
        {
            get
            {
                return a => new PostOutputData
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    UserId  = a.UserId
                };
            }
        }
    }
}