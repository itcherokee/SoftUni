// Task 1:  We are given a school. In the school, there are classes of students. 
//          • Each class has a set of teachers. 
//          • Each teacher teaches a set of disciplines. 
//          • Students have name and unique class number. Classes have unique text 
//            identifier. Teachers have name. Disciplines have name, number of lectures 
//            and students. Both teachers and students are people. Students, classes, 
//            teachers and disciplines have details (optional field).
//          Your task is to identify the classes (in terms of OOP) and their members, 
//          encapsulate their fields, define the class hierarchy (inherit shared data 
//          and functionality) and create a class diagram with Visual Studio.

namespace MySchool
{
    using System;

    public class TestExec
    {
        public static void Main()
        {
            // Create & loads Teacher & Disciplines
            Teacher teacherOne = new Teacher("Goshko", "Goshkov");
            Discipline disciplineOne = new Discipline("Mathematica", 4, 10);
            Discipline disciplineTwo = new Discipline("Phisics", 10, 6);
            teacherOne.AddDiscipline(disciplineOne);
            teacherOne.AddDiscipline(disciplineTwo);

            // Create & loads students
            Student studentOne = new Student("Petarcho", "Petarchov", 1);
            Student studentTwo = new Student("Yordancho", "Yordanov", 2);
            Student studentThree = new Student("Zuyo", "Zuev", 1);
            Student studentFour = new Student("Suzi", "Suzankovichkova", 2);

            // Create & loads class with students and teachers
            Class classOne = new Class("Class One");
            try
            {
                classOne.AddStudent(studentOne);
                classOne.AddStudent(studentTwo);
                classOne.AddTeacher(teacherOne);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Teacher teacherTwo = new Teacher("Petunia", "Petunkova", new Discipline("Rocket Science", 1000, 6000));
            Class classTwo = new Class("Class Two");
            try
            {
                classTwo.AddStudent(studentThree);
                classTwo.AddStudent(studentFour);
                classTwo.AddTeacher(teacherOne);
                classTwo.AddTeacher(teacherTwo);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            // Create & loads school and add class
            School school = new School();
            school.AddClass(classOne);
            school.AddClass(classTwo);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("School details:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(school.ToString());
        }
    }
}
