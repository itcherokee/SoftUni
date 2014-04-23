namespace StudentSystem.Models
{
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}
