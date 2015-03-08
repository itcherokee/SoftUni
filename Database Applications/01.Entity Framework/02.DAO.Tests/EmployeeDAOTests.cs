namespace EmployeeDAOTests
{
    using System;
    using System.Linq;
    using EmployeeDataAccessObject;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SoftUniDBContext;

    [TestClass]
    public class EmployeeDAOTests
    {
        private Department department;

        [TestInitialize]
        public void TestInitialize()
        {
            using (var context = new SoftUniContext())
            {
                this.department = context.Departments.FirstOrDefault();
                if (this.department == null)
                {
                    this.department = new Department() { Name = "Unknown" };
                    context.Departments.Add(this.department);
                    context.SaveChanges();
                }
            }
        }

        [TestMethod]
        public void AddEmployee()
        {
            var employee = new Employee()
            {
                FirstName = "Test",
                LastName = "Tester",
                JobTitle = "Newbee tester",
                HireDate = DateTime.Now,
                Salary = 0,
                DepartmentID = this.department.DepartmentID
            };

            EmployeeDao.Insert(employee);

            using (var context = new SoftUniContext())
            {
                var retrievedEmployee = context.Employees.FirstOrDefault(x => x.JobTitle == "Newbee tester");
                Assert.AreEqual(
                    employee.FirstName + employee.LastName + employee.JobTitle,
                    retrievedEmployee.FirstName + retrievedEmployee.LastName + retrievedEmployee.JobTitle);
            }
        }

        [TestMethod]
        public void UpdateEmployeeNewJobTitle()
        {
            using (var context = new SoftUniContext())
            {
                var employee = context.Employees.FirstOrDefault(x => x.JobTitle == "Newbee tester");
                employee.JobTitle = "Edited newbee tester";
                EmployeeDao.Update(employee);
                var retrievedEmployee = context.Employees.FirstOrDefault(x => x.JobTitle == "Edited newbee tester");

                Assert.AreEqual(
                    employee.FirstName + employee.LastName + employee.JobTitle,
                    retrievedEmployee.FirstName + retrievedEmployee.LastName + retrievedEmployee.JobTitle);
            }
        }

        [TestMethod]
        public void DeleteEmployee()
        {
            using (var context = new SoftUniContext())
            {
                var employee = context.Employees.FirstOrDefault(x => x.JobTitle == "Edited newbee tester");
                EmployeeDao.Delete(employee);
                var isEmployeeExists = context.Employees.FirstOrDefault(x => x.JobTitle == "Edited newbee tester");

                Assert.IsNull(isEmployeeExists);
            }
        }
    }
}
