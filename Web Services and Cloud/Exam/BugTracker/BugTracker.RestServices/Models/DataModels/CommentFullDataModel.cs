namespace BugTracker.RestServices.Models.DataModels
{
    using System;
    using System.Linq.Expressions;

    using Data.Models;

    public class CommentFullDataModel
    {
        // Id, Text, Author, DateCreated, BugId and BugTitle. 

        public static Expression<Func<Comment, CommentFullDataModel>> DataModel
        {
            get
            {
                return x => new CommentFullDataModel()
                {
                    Id = x.Id,
                    Text = x.Text,
                    Author = x.Author.UserName,
                    DateCreated = x.DateCreated,
                    BugId = x.BugId,
                    BugTitle = x.Bug.Title
                };
            }
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public int BugId { get; set; }

        public string BugTitle { get; set; }
    }
}