namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Enumerations;

    public class Homework
    {
        public Homework()
        {
            this.SubmitedOn = DateTime.Now;
        }

        public int HomeworkId { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        public ContentType Type { get; set; }

        public DateTime SubmitedOn { get; private set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
