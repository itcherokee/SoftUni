namespace StudentSystem.Data
{
    using System.Data.Entity;
    using Models;
    using StudentSystem.Data.Migrations;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext() :base()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>() );
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}
