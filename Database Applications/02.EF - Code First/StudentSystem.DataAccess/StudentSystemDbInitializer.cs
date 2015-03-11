namespace StudentSystem.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Model;
    using Model.Enumerations;

    public class StudentSystemDbInitializer : DropCreateDatabaseIfModelChanges<StudentSystemDbContext>
    {
        protected override void Seed(StudentSystemDbContext context)
        {
            IList<Course> courses = new List<Course>()
                    {
                        new Course
                        {
                            Name = "Math 101",
                            Description = "Basic Math",
                            StartDate = new DateTime(2015, 4, 1),
                            EndDate = new DateTime(2014, 5, 1),
                            Price = 0.00m,
                            Resources = new List<Resource>
                            {
                                new Resource() { Name = "Math - Numbers", Link = "http://www.youtube.com/watch?v=yT3jh2aZN68", Type = ResourceType.Video },
                                new Resource() { Name = "Math - Equalities & Inequalities", Link = "http://www.youtube.com/watch?v=NFJdIK6Ydgc", Type = ResourceType.Video },
                                new Resource() { Name = "Math - Operations on Numbers -- Part 1", Link = "http://www.youtube.com/watch?v=mUkRgGFKv2k", Type = ResourceType.Video },
                                new Resource() { Name = "Math - Operations on Numbers -- Part 2", Link = "http://www.youtube.com/watch?v=cipckeeozBE", Type = ResourceType.Video },
                                new Resource() { Name = "Math - Operations on Numbers -- Part 3", Link = "http://www.youtube.com/watch?v=hUiox5ZMJb0", Type = ResourceType.Video }
                            }
                        },
                        new Course
                        {
                            Name = "Physics 101",
                            Description = "Basic Physics",
                            StartDate = new DateTime(2015, 4, 15),
                            EndDate = new DateTime(2014, 6, 1),
                            Price = 100.00m,
                            Resources = new List<Resource>
                            {
                                new Resource() { Name = "Physics - Dynamics and Physics Equations", Link = "http://www.ebook3000.com/upimg/201011/13/18591539.jpeg", Type = ResourceType.Video }
                            }
                        },
                        new Course
                        {
                            Name = "Biology",
                            Description = "All big universe of biology",
                            StartDate = new DateTime(2015, 3, 1),
                            EndDate = new DateTime(2014, 10, 1),
                            Price = 500.00m,
                            Resources =  new List<Resource>
                            {
                                new Resource() { Name = "Biology - A tour of the cell", Link = "http://www.youtube.com/watch?v=1Z9pqST72is", Type = ResourceType.Video },
                                new Resource() { Name = "Biology - Cell Biology Lecture Notes", Link = "https://www.google.bg/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&ved=0CB8QFjAA&url=http%3A%2F%2Fwww.wjmmackay.com%2Fuploads%2F4%2F2%2F7%2F2%2F4272503%2Fcell_biology_lecture_notes.doc&ei=W4H9VJaFDcyMaOjDgpAG&usg=AFQjCNGfvn5_rR2cSrN35SoDrIFyGNK4tA&sig2=pe15qrm9Si8beJH2EMFdRA&bvm=bv.87611401,d.d2s&cad=rjt", Type = ResourceType.Document },
                                new Resource() { Name = "Biology - Cell Biology", Link = "https://www.google.bg/url?sa=t&rct=j&q=&esrc=s&source=web&cd=3&cad=rja&uact=8&ved=0CDUQFjAC&url=http%3A%2F%2Fweb.calstatela.edu%2Ffaculty%2Fmchen%2F433%2FCell%2520Biology.ppt&ei=x4H9VKOnHJXsaPupgqAP&usg=AFQjCNFbDdKfQ6TzoMjnJ-pGrxkLcM86gw&sig2=cRHziabmcAxoGJvALjB4vw&bvm=bv.87611401,d.d2s", Type = ResourceType.Presentation }
                            }
                        }
                    };

            IList<Student> students = new List<Student>()
                    {
                        new Student()
                        {
                            Name = "Goshko",
                            PhoneNumber = "123-456-789",
                            Birthday = new DateTime(2000, 1, 1),
                            RegistrationDate = new DateTime(2014, 2, 2),
                            Courses = new List<Course>{courses[0],courses[1]}
                          },
                        new Student()
                        {
                            Name = "Peshko",
                            PhoneNumber = "654-987",
                            Birthday = new DateTime(2001, 1, 1),
                            RegistrationDate = new DateTime(2014, 12, 2),
                            Courses = courses.Where(c=> c.Name == "Biology").ToList()
                        },
                        new Student()
                        {
                            Name = "Clechko",
                            PhoneNumber = "02/123456",
                            Birthday = new DateTime(2001, 2, 1),
                            RegistrationDate = new DateTime(2014, 2, 24)
                        },
                        new Student()
                        {
                            Name = "Nakcho",
                            PhoneNumber = "0888/456789",
                            Birthday = new DateTime(1999, 1, 1),
                            RegistrationDate = new DateTime(2014, 4, 2),
                            Courses = new List<Course>{courses[0],courses[1], courses[2]}
                        },
                        new Student()
                        {
                            Name = "Toshko",
                            PhoneNumber = "123456987",
                            Birthday = new DateTime(2004, 1, 1),
                            RegistrationDate = new DateTime(2014, 3, 2),
                                   Courses = new List<Course>{courses[0],courses[2]}
                        }
                    };

            IList<Homework> homeworks = new List<Homework>
            {
                new Homework
                {
                    Content = new byte[] {0, 8, 9, 9, 9, 6, 4, 3, 4, 45, 6, 76, 78, 8, 8, 4, 7},
                    Student = students[0],
                    Type = ContentType.ApplicationPdf,
                    Course = courses[0]
                },
                new Homework
                {
                    Content = new byte[] {0,0,0,0,0,0,0},
                    Student = students[1],
                    Type = ContentType.ApplicationRar,
                    Course = courses[0]
                },
                new Homework
                {
                    Content = new byte[] {0, 8, 9, 9, 9, 6, 78, 8, 8, 4, 7},
                    Student = students[1],
                    Type = ContentType.ApplicationPdf,
                    Course = courses[2]
                }
            };

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Courses.AddOrUpdate(courses.ToArray());
                    context.Students.AddOrUpdate(students.ToArray());
                    context.Homeworks.AddOrUpdate(homeworks.ToArray());
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                finally
                {
                    base.Seed(context);
                }
            }
        }
    }
}
