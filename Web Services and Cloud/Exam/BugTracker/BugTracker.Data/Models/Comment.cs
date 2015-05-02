using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string    AuthorId { get; set; }

        public User Author { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public int BugId { get; set; }

        public virtual Bug Bug { get; set; }
    }
}
