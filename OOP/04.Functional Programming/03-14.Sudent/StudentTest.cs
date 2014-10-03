namespace University
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentTest
    {
        public static void Main()
        {
            var students = new Students 
            {
                new Student
                {
                   FirstName = "Anton",
                   LastName = "Petrov",
                   Age = 17,
                   GroupNumber = 2,
                   GroupName = "Zevzeci",
                   Email = "hoho@abv.bg",
                   Phone = "023444908",
                   FacultyNumber = 103414,
                   Marks = new List<byte> { 4, 6, 2, 2 },
               },
               new Student
               {
                   FirstName = "Zoro",
                   LastName = "Petrov",
                   Age = 24,
                   GroupNumber = 3,
                   GroupName = "Mandradjii",
                   Email = "zoro@mail.bg",
                   Phone = "+35923444908",
                   FacultyNumber = 233414,
                   Marks = new List<byte> { 2, 6, 4, 6 },
               },
               new Student
               {
                   FirstName = "Petyo",
                   LastName = "Zabov",
                   Age = 19,
                   GroupNumber = 2,
                   GroupName = "Zevzeci",
                   Email = "haralampi@abv.bg",
                   Phone = "0323444908",
                   FacultyNumber = 544506,
                   Marks = new List<byte> { 2, 2 },
               },
               new Student
               {
                   FirstName = "Nikola",
                   LastName = "Gogov",
                   Age = 18,
                   GroupNumber = 1,
                   GroupName = "Piloti",
                   Email = "nikola.gogov@abv.bg",
                   Phone = "+359 2 34 44 908",
                   FacultyNumber = 123413,
                   Marks = new List<byte> { 2, 2, 2, 2 },
               },
            };

            // Task 4
            SetTaskTitle("4", "Students with Group Number = 2 (using LINQ):");
            foreach (var student in students.GroupMemberLinq(2))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Group));
            }

            // Task 5
            SetTaskTitle("5", "Students with First name are before their Last name:");
            foreach (Student student in students.FirstBeforeLast())
            {
                Console.WriteLine("Student: {0}", student);
            }

            // Task 6
            SetTaskTitle("6", "Students with Age between 18 and 24:");
            foreach (dynamic student in students.AgeBetween(18, 24))
            {
                Console.WriteLine("Student: {0} {1} (Age:{2})", student.FirstName, student.LastName, student.Age);
            }

            NextPage();

            // Task 7a
            SetTaskTitle("7a", "Students sorted in descending (first,last) using lambda expression:");
            foreach (Student student in students.SortExtension())
            {
                Console.WriteLine("Student: {0}", student);
            }

            // Task 7b
            SetTaskTitle("7b", "Students sorted in descending (first,last) using LINQ:");
            foreach (Student student in students.SortLinq())
            {
                Console.WriteLine("Student: {0}", student);
            }

            NextPage();

            // Task 8
            SetTaskTitle("8", "Students with e-mail from abv.bg (LINQ):");
            foreach (Student student in students.MatchEmailDomain("abv.bg"))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Email));
            }

            // Task 9
            SetTaskTitle("9", "Students with Sofia's area phone number :");
            foreach (Student student in students.MatchPhoneCode(new[] { "02", "+359 2", "+3592" }))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Tel));
            }

            NextPage();

            // Task 10
            SetTaskTitle("10", "Students with at least one mark of 6:");
            foreach (dynamic student in students.MatchMark(6))
            {
                Console.WriteLine("Student: Full name:{0}; {1}", student.FullName, string.Join(",", student.Marks));
            }

            // Task 11a
            SetTaskTitle("11a", "Students with exactly two marks \"2\" (could have others as well):");
            foreach (dynamic student in students.MatchMarkCount(2, 2))
            {
                Console.WriteLine("Student: {0}; {1}", student.FullName, string.Join(",", student.Marks));
            }

            // Task 11b
            SetTaskTitle("11b", "Students with exactly two marks \"2\" (only these marks):");
            foreach (dynamic student in students.MatchMarkCountDistinct(2, 2))
            {
                Console.WriteLine("Student: {0}; {1}", student.FullName, string.Join(",", student.Marks));
            }

            NextPage();

            // Task 12
            SetTaskTitle("12", "Students enrolled in 2014 with their marks:");
            foreach (Student student in students.Enrolled(2014))
            {
                Console.WriteLine("Student: {0}", student.ToString(Fields.First | Fields.Last | Fields.Fn | Fields.Marks));
            }

            // Task 13
            SetTaskTitle("13", "Students by Groups:");
            var grouped = from student in students.GetAllStudents()
                          group student by student.GroupName into grouping
                          select grouping;

            foreach (var group in grouped)
            {
                Console.WriteLine("Group: {0}", group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("\t{0}", student.ToString(Fields.First | Fields.Last));
                }
            }

            // Task 14
            SetTaskTitle("14", "* Students joined to specialities:");
            var specialities = new List<StudentSpeciality>
                                {
                                     new StudentSpeciality { Name = "Web Developer", FacultyNumber = 103414 },   
                                     new StudentSpeciality { Name = "QA Engineer", FacultyNumber = 123413 },   
                                     new StudentSpeciality { Name = "Web Developer", FacultyNumber = 233414 },   
                                     new StudentSpeciality { Name = "PHP Developer", FacultyNumber = 544506 },   
                                     new StudentSpeciality { Name = "Haskel Developer", FacultyNumber = 544506 },   
                                     new StudentSpeciality { Name = "Web Developer", FacultyNumber = 544506 },   
                                     new StudentSpeciality { Name = "JavaScript Developer", FacultyNumber = 233414 },   
                                     new StudentSpeciality { Name = "QA Engineer", FacultyNumber = 103414 },   
                                };

            var joinedList = from student in students.GetAllStudents()
                             join speciality in specialities on student.FacultyNumber equals speciality.FacultyNumber
                             orderby student.FirstName, student.LastName
                             select new
                             {
                                 FullName = student.FirstName + " " + student.LastName,
                                 FN = student.FacultyNumber,
                                 Speciality = speciality.Name
                             };

            foreach (dynamic student in joinedList)
            {
                Console.WriteLine("Student: {0} - {1} - {2}", student.FullName, student.FN, student.Speciality);
            }

            NextPage();
        }

        private static void SetTaskTitle(string taskNumber, string description)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Task {0}: ", taskNumber);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(description);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void NextPage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
