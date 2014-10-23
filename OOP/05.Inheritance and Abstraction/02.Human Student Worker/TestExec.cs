// Task 2:  Define an abstract class Human holding a first name and a last name.
//          • Define a class Student derived from Human that has a field faulty number (5-10 digits / letters).
//          • Define a class Worker derived from Human with fields WeekSalary and WorkHoursPerDay and method 
//            MoneyPerHour() that returns the payment earned by hour by the worker. 
//          • Define the proper constructors and properties for the classes in your class hierarchy.
//          • Initialize a list of 10 students and sort them by faculty number in ascending order 
//            (use LINQ or OrderBy() extension method). Initialize a list of 10 workers and sort them by payment 
//            per hour in descending order.
//          •Merge the lists and then sort them by first name and last name.

namespace People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TestExec
    {
        public static void Main()
        {
            // create list with/and students
            var students = new List<Student>()
            {
                        new Student("Asen", "Asenov", "a123456"),
                        new Student("Asen", "Balakov", "a23233"),
                        new Student("Asen", "Georgiev", "b093485"),
                        new Student("Asen", "Ivanov", "b094485"),
                        new Student("Asen", "Kamarov", "a093485"),
                        new Student("Asen", "Nikolov", "aq223485"),
                        new Student("Asen", "Petrov", "b0934454"),
                        new Student("Asen", "Rusev", "c0023485"),
                        new Student("Asen", "Sosev", "c093485"),
                        new Student("Asen", "Yonkov", "b000085") 
            };

            // Query and print students sorted by faculty number in ascending order
            var queryStudents = from student in students
                                orderby student.FacultyNumber
                                select student;

            Console.WriteLine("Students:");
            foreach (var student in queryStudents)
            {
                Console.WriteLine(student);
            }

            // Create list with workers
            var workers = new List<Worker>() 
            {
                        new Worker("Zelyo", "Asenov"),
                        new Worker("Zelyo", "Bozev"),
                        new Worker("Zelyo", "Cocev"),
                        new Worker("Zelyo", "Ivanov"),
                        new Worker("Zelyo", "Kirov"),
                        new Worker("Zelyo", "Lyolev"),
                        new Worker("Zelyo", "Minkov"),
                        new Worker("Zelyo", "Naroden"),
                        new Worker("Zelyo", "Onev"),
                        new Worker("Zelyo", "Zelyov", 3, 1000.0m) 
            };

            // Assign random working hours per day to workers (except last one who already have)
            Random workHoursPerDay = new Random();
            for (int index = 0; index < workers.Count - 1; index++)
            {
                workers[index].WorkHoursPerDay = workHoursPerDay.Next(0, 23);
            }

            // Assign random week salaries to workers (except last one who already have)
            Random salary = new Random();
            for (int index = 0; index < workers.Count - 1; index++)
            {
                workers[index].WeekSalary = salary.Next(1, 8000);
            }

            // Print workers sorted by money per hour in descending order
            var queryWorkers = workers.OrderByDescending(x => x.MoneyPerHour());

            // var queryWorkers = from worker in workers
            //                   orderby worker.MoneyPerHour()
            //                   select worker;
            Console.WriteLine("\nWorkers:");
            foreach (var worker in queryWorkers)
            {
                Console.Write("{0}  Salary per Hour: {1:C2}\n", worker, worker.MoneyPerHour());
            }

            // Merge and sort the lists (Students & Workers)
            Console.WriteLine("\nCombined List:");
            IEnumerable<Human> mergedList = queryStudents
                                            .Concat<Human>(queryWorkers)
                                            .OrderBy(x => x.FirstName)
                                            .ThenByDescending(x => x.LastName);

            Console.WriteLine(string.Join("\n", mergedList));
        }
    }
}