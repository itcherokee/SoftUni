namespace BugTracker.RestServices.Models.DataModels
{
    using System;
    using System.Linq.Expressions;

    using Data.Models;

    public class CommentDataModel
    {
        public static Expression<Func<Comment, CommentDataModel>> DataModel
        {
            get
            {
                return x => new CommentDataModel()
                {
                    Id = x.Id,
                    Text = x.Text,
                    Author = x.Author.UserName,
                    DateCreated = x.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}