namespace EmployeeDataAccessObject
{
    using SoftUniDBContext;

    public static class EmployeeDao
    {
        public static void Insert(Employee employee)
        {
            using (var context = new SoftUniContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public static void Update(Employee employee)
        {
            using (var context = new SoftUniContext())
            {
                Employee employeeToUpdate = context.Employees.Find(employee.EmployeeID);
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.MiddleName = employee.MiddleName;
                employeeToUpdate.DepartmentID = employee.DepartmentID;
                employeeToUpdate.ManagerID = employee.ManagerID ?? null;
                employeeToUpdate.JobTitle = employee.JobTitle;
                employeeToUpdate.HireDate = employee.HireDate;
                employeeToUpdate.Salary = employee.Salary;
                employeeToUpdate.AddressID = employee.AddressID ?? null;
                context.SaveChanges();
            }
        }

        public static void Delete(Employee employee)
        {
            using (var context = new SoftUniContext())
            {
                Employee employeeToDelete = context.Employees.Find(employee.EmployeeID);
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();
            }
        }
    }
}
