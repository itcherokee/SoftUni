namespace Company
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Manager : Employee, IManager
    {
        private readonly Dictionary<uint, Employee> employees;

        public Manager(string firstName, string lastName, uint id, decimal salary, Department department, ICollection<Employee> employees)
            : this(firstName, lastName, id, salary, department)
        {
            this.Employees = employees;
        }

        public Manager(string firstName, string lastName, uint id, decimal salary, Department department)
            : base(firstName, lastName, id, salary, department)
        {
            this.employees = new Dictionary<uint, Employee>();
        }

        public ICollection<Employee> Employees
        {
            get
            {
                return this.employees.Values.ToList().AsReadOnly();
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Employee list cannot be null.");
                }

                foreach (var employee in value)
                {
                    this.AddEmployee(employee);
                }
            }
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("employee", "Employee cannot be null.");
            }

            if (this.employees.ContainsKey(employee.Id))
            {
                throw new ArgumentException("This employee is already in the list.");
            }

            this.employees.Add(employee.Id, employee);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Position: Manager");
            output.AppendLine(base.ToString());
            output.AppendLine("Employees in command:");
            output.Append(string.Format("{0}", string.Join(string.Empty, this.Employees.Select(x => x.ToString(true)))));

            return output.ToString();
        }
    }
}
