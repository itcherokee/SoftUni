// Task 03: ** Define a class Person and the classes Trainer, Student. There are two types of 
//          trainers – Junior and Senior Trainer. There are three types of Students – Graduate, 
//          Current and Dropout Student. There are two types of Current Students – Online and 
//          Onsite Student. Implement the given structure below. A class down the hierarchy 
//          should implement the fields, properties and methods of the classes above it...

namespace Learn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SULSTest
    {
        public static void Main()
        {
            var uniPeople = new List<Person>()
            {
                new JuniorTrainer("Goshko", "Goshkov", 23),
                new JuniorTrainer("Petko", "Nikolov", 19),
                new SeniorTrainer("Mitko", "Leshtarov", 30),
                new JuniorTrainer("Tonkcho", "Dimitrov", 22),
                new GraduateStudent("Nikola", "Grozdanov", 32, 123002, 3.6),
                new GraduateStudent("Lidia", "Grozdanova", 30, 123003, 5.6),
                new GraduateStudent("Vesela", "Petkova", 26, 123004, 4.2),
                new GraduateStudent("Petar", "Semkov", 24, 123005, 5.0),
                new GraduateStudent("Mitko", "Nonev", 34, 123006, 6.0),
                new DropoutStudent("Pencho", "Penchev", 20, 123007, 2.0, "Myrzel"),
                new DropoutStudent("Tikvon", "Tikvov", 21, 123008, 2.1, "Malko po malyk myrzel"),
                new DropoutStudent("Nikoleta", "Andonova", 19, 123009, 2.0, "Gadzheto zamina v chujbina"),
                new DropoutStudent("Petraki", "Penchev", 33, 123010, 6.0, "propusnat izpit po Java"),
                new OnlineStudent("Leni", "Kravitz", 50, 123001, 4.4, "Math"),
                new OnlineStudent("Vladimir", "Nonev", 20, 123011, 5.3, "Math"),
                new OnlineStudent("Valyo", "Rashkov", 19, 123012, 6.0, "Geography"),
                new OnlineStudent("Fatim", "Totev", 21, 123013, 5.1, "Lyrics"),
                new OnsiteStudent("Mirela", "Manolova", 23, 123014, 5.9, 23, "Math"),
                new OnsiteStudent("Kliment", "Nikolov", 23, 123015, 4.8, 21, "Lyrics"),
                new OnsiteStudent("Anton", "Toshev", 23, 123016, 6.0, 25, "Lyrics"),
                new OnsiteStudent("Georgi", "Georgiev", 23, 123017, 6.0, 25, "Lyrics"),
                new OnsiteStudent("Sasho", "Fedorov", 23, 123018, 4.9, 31, "Math"),
                new OnsiteStudent("Vesko", "Klekov", 23, 123019, 3.0, 3, "Geography"),
                new OnsiteStudent("Toni", "Nikolova", 23, 123020, 5.4, 26, "Math"),
            };

            var query =
                uniPeople.Where(x => x is CurrentStudent)
                    .OrderBy(x => (x as CurrentStudent).AverageGrade).ToList();

            foreach (var student in query)
            {
                Console.WriteLine(student.ToString());
                Console.WriteLine(new string('-', 20));
            }

            Console.ReadKey();
        }
    }
}
