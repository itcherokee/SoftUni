using System.Linq;
using StudentSystem.Data;
using StudentSystem.Models;

namespace StudentSystem.Console
{
    public class ConsoleClient
    {
        public static void Main()
        {
            var data = new StudentSystemDbContext();

            var course = new Course
            {
                Name = "Code First",
                Description = "Entity Frameset 101"
            };

            data.Courses.Add(course);
            data.SaveChanges();

            var count = data.Courses.Count();
            System.Console.WriteLine(count);

            
            foreach (var courseInData in data.Courses)
            {
                System.Console.WriteLine(courseInData.Name);

            }
        }
    }
}
