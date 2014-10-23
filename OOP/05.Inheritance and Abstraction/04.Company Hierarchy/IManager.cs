namespace Company
{
    using System.Collections.Generic;

    public interface IManager : IEmployee
    {
        ICollection<Employee> Employees { get; }

        void AddEmployee(Employee employee);
    }
}