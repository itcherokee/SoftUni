namespace BugTracker.RestServices.Models.DataModels
{
    using System;
    using System.Linq.Expressions;

    using Data.Models;

    public class BugDataModel
    {
        public static Expression<Func<Bug, BugDataModel>> DataModel
        {
            get
            {
                return x => new BugDataModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Status = x.Status.ToString(),
                    Author = x.Author.UserName,
                    DateCreated = x.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}