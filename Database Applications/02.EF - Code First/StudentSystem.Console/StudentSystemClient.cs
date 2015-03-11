namespace StudentSystem.Console
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DataAccess;
    using Model;
    using Model.Enumerations;

    public class StudentSystemClient
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new StudentSystemDbInitializer());

            using (var context = new StudentSystemDbContext())
            {
                Console.WriteLine("Task 3.1: List all students and their homework submissions:");
                var students = context.Students.Include("Homeworks");
                foreach (var student in students)
                {
                    Console.WriteLine("Student: {0} ; Submitted homeworks count: {1}", student.Name, student.Homeworks.Count());
                }

                Console.WriteLine("\nTask 3.2: List all courses and their resources:");
                var courses = context.Courses.Include("Resources");
                foreach (var course in courses)
                {
                    Console.WriteLine("Course: \"{0}\" with following resources:", course.Name);
                    foreach (var resource in course.Resources)
                    {
                        Console.WriteLine("\t- \"{0}\" - [Type: {1}]", resource.Name, resource.Type);
                    }
                }

                Console.WriteLine("\nTask 3.3: Adds a new course with some resources:");
                var newCourse = new Course
                {
                    Name = "C# Programming - Beginning",
                    Description = "Learn to code in C#",
                    StartDate = DateTime.Now,
                    Price = 0.01m,
                    Resources = new List<Resource>
                    {
                        new Resource { Name = "C# Programming", Type = ResourceType.Document, Link = "search in bookstores" },
                        new Resource { Name = "Head First C#", Type = ResourceType.Document, Link = "http://it-ebooks.info/book/251/" },
                    }
                };

                context.Courses.Add(newCourse);
                context.SaveChanges();
                Console.WriteLine("Added course ID in DB is: {0}", newCourse.CourseId);
                Console.WriteLine("This new course have {0} resources", newCourse.Resources.Count());

                Console.WriteLine("\nTask 3.4: Add a new student:");
                var newStudent = new Student
                {
                    Name = "Svetlin Nakov",
                    Birthday = new DateTime(1900, 1, 1),
                    RegistrationDate = DateTime.Now
                };

                context.Students.Add(newStudent);
                context.SaveChanges();
                Console.WriteLine("Added student ID in DB is: {0}", newStudent.StudentId);

                Console.WriteLine("\nTask 3.5: Add a new resource:");
                var newResource = new Resource
                {
                    Name = "Book with pictures",
                    Type = ResourceType.Document,
                    Link = "look into kindergarden",
                    Course = context.Courses.FirstOrDefault(),
                };

                context.Resources.Add(newResource);
                context.SaveChanges();
                Console.WriteLine("Added resource ID in DB is {0} and is assigned to course \"{1}\"", newResource.ResourceId, newResource.Course.Name);
            }
        }
    }
}