namespace BlogSystem.Web.Models
{
    using System;
    using System.Linq.Expressions;
    using BlogSystem.Models;

    public class TagOutputData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Tag, TagOutputData>> FromTag
        {
            get
            {
                return a => new TagOutputData
                {
                    Id = a.Id,
                    Name = a.Name
                };
            }
        }
    }
}