using System;
using System.Collections;
using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Course
    {
        public Course()
        {
            this.Student = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Student> Student { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}
