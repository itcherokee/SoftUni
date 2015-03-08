namespace QueriesAndConcurentAccess
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using SoftUniDBContext;

    public class QueriesAndConcurentAccess
    {
        private const int InitialProjectYear = 2002;

        public static void Main()
        {
            // Problem 3:   Your task is to write a method that finds all employees 
            //              who have projects with start date in 2002 year
            Console.WriteLine("Problem 3: Employees with projects after 2001 (2002-...):");
            OutputEmployees(ProjectsStartedAfter(InitialProjectYear));
            Console.WriteLine("Press a key to continue to next problem...\n");
            Console.ReadKey();

            // Problem 4:   Your task is to solve the previous task by using native SQL query 
            //              and executing it through the DbContext.
            Console.WriteLine("Problem 4: Employees with projects after 2001 (2002-...) - native SQL:");
            OutputEmployees(ProjectsStartedAfterSql(InitialProjectYear));
            Console.WriteLine("Press a key to continue to next problem...\n");
            Console.ReadKey();

            // Problem 5:   Your task is to write a method that finds all employees by specified 
            //              department (name) and manager (first name and last name).
            const string Manager = "James Hamilton";
            const string Department = "Production Control";
            Console.WriteLine("Problem 5: All employees in {0} department with boss {1}:", Department, Manager);
            OutputEmployees(FilterEmployees(Department, Manager));
            Console.WriteLine("Press a key to continue to next problem...\n");
            Console.ReadKey();

            // Problem 6:   Your task is to try to open two different data contexts and to perform 
            //              concurrent changes on the same records in some database table. 
            //              What will happen at SaveChanges()? How to deal with it?
            var contextOne = new SoftUniContext();
            var contextTwo = new SoftUniContext();
            var contextOnlyReader = new SoftUniContext();
            const int EmployeeId = 101;

            contextOne.Employees.Find(EmployeeId).FirstName = "First";
            contextTwo.Employees.Find(EmployeeId).FirstName = "Second";
            contextOne.SaveChanges();
            contextTwo.SaveChanges();
            Console.WriteLine("Problem 6: " + contextOnlyReader.Employees.Find(EmployeeId).FirstName);
            Console.WriteLine("Press a key to continue to next problem...\n");
            Console.ReadKey();

            //// Problem 7:   Your task is to create a class, which allows employees to access their 
            ////              corresponding territories as property of the type EntitySet<T> by inheriting 
            ////              the Employee entity class or by using a partial class.
            //// see two classes in the folder (Territory & AdvancedEmployee)
            
            //// Problem 8:   Your task is to create a method that inserts a new project in the SoftUni database.
            ////              The project should contain several employees.

            using (var context = new SoftUniContext())
            {
                var members = GetEmployeesInDepartment("Information Services");
                var projectId = CreateProject("Total IS Infrastructure Re-Design", "Change everything", members);
                Console.WriteLine("Problem 8: Id of the new project: {0} (members count: {1})", projectId, members.Count());
            }

            Console.WriteLine("Press a key to continue to next problem...\n");
            Console.ReadKey();

            // Problem 9:   Your task is to create a stored procedure in the SoftUni database for finding 
            //              all projects for given employee (first name and last name). Using EF implement 
            //              a C# method that calls the stored procedure and returns the retuned record set.
            //// Run the SQl query in file sp_sql.sql in project folder to create SP
            //// Than map the SP to DBContext in first project - 01.DBContextForSoftUni

            Console.WriteLine("Problem 9: Projects for employee Gilbert Guy: ");
            foreach (var project in GetEmployeeProjects("Gilbert", "Guy"))
            {
                Console.WriteLine(project.GetType().GetProperty("Name").GetValue(project));
            }

            Console.WriteLine("Press a key to EXIT\n");
            Console.ReadKey();
        }

        private static IEnumerable GetEmployeeProjects(string firstName, string lastName)
        {
            using (var context = new SoftUniContext())
            {
                var projects = context.usp_AllProjectsByEmployee(lastName, firstName).ToList();
                return projects;
            }
        }

        private static int? CreateProject(string projectName, string description, IEnumerable<Employee> projectMembers)
        {
            using (var context = new SoftUniContext())
            {
                if (context.Projects.FirstOrDefault(p => p.Name == projectName) == null)
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var project = new Project()
                            {
                                Name = projectName,
                                Description = description,
                                StartDate = DateTime.Now,
                            };

                            foreach (var member in projectMembers)
                            {
                                context.Entry(member).State = EntityState.Unchanged;
                                project.Employees.Add(member);
                            }

                            context.Projects.Add(project);

                            context.SaveChanges();

                            transaction.Commit();

                            return project.ProjectID;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }

            return null;
        }

        private static IEnumerable<string> FilterEmployees(string department, string manager)
        {
            using (var context = new SoftUniContext())
            {
                var managerId = context.Employees
                    .Where(m => (m.FirstName + " " + m.LastName) == manager)
                    .Select(m => m.EmployeeID);

                var departmentId = context.Departments
                     .Where(d => d.Name == department)
                     .Select(d => d.DepartmentID);

                var employees = context.Employees
                    .Where(e => e.DepartmentID == departmentId.FirstOrDefault() && e.ManagerID == managerId.FirstOrDefault())
                       .Select(e => e.FirstName + " " + e.LastName);

                return employees.ToList();
            }
        }

        private static IEnumerable<string> ProjectsStartedAfterSql(int year)
        {
            const string Query = "SELECT DISTINCT FirstName + ' ' + LastName as emp " +
                                 "FROM Employees e " +
                                 "JOIN EmployeesProjects ep ON e.EmployeeID=ep.EmployeeID " +
                                 "JOIN Projects p ON ep.ProjectID=p.ProjectID " +
                                 "WHERE p.StartDate >= {0}";
            var parameters = new object[] { year };

            using (var context = new SoftUniContext())
            {
                var employees = context.Database.SqlQuery<string>(Query, parameters);

                return employees.ToList();
            }
        }

        private static IEnumerable<string> ProjectsStartedAfter(int year)
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(e => e.Projects.Any(pr => pr.StartDate.Year >= year))
                    .Select(e => e.FirstName + " " + e.LastName);

                return employees.ToList();
            }
        }

        private static void OutputEmployees(IEnumerable<string> employees)
        {
            Console.WriteLine(string.Join(", ", employees));
        }

        private static ICollection<Employee> GetEmployeesInDepartment(string departmentName)
        {
            using (var context = new SoftUniContext())
            {
                var query = context.Employees
                    .Where(d => d.Department.Name == departmentName)
                    .ToList();

                return query;
            }
        }
        }
}
