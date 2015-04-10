namespace BlogSystem.Web.Models
{
    using System;
    using System.Linq.Expressions;
    using BlogSystem.Models;
    
    public class UserOutputData
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public string Facebook { get; set; }

        public string Skype { get; set; }

        public string Tweeter { get; set; }

        public string PhoneNumber { get; set; }

        public static Expression<Func<User, UserOutputData>> FromUser
        {
            get
            {
                return a => new UserOutputData
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    Gender = a.Gender,
                    Birthday = a.Birthday
                };
            }
        }
    }
}