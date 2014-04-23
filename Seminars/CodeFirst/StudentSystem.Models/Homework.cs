using System;

namespace StudentSystem.Models
{
    public class Homework
    {
        public int  Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
