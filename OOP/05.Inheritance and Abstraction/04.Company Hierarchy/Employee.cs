namespace Company
{
    using System;
    using System.Text;

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        protected Employee(string firstName, string lastName, uint id, decimal salary, Department department)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be a negative number.");
                }

                this.salary = value;
            }
        }

        public Department Department
        {
            get
            {
                return this.department;
            }

            set
            {
                if (Enum.IsDefined(typeof(Department), value))
                {
                    this.department = value;
                }
                else
                {
                    throw new ArgumentException("Invalid enum value provided for department.");
                }
            }
        }

        public int CompareTo(Employee other)
        {
            if (this.Id == other.Id)
            {
                return 0;
            }

            if (this.Id < other.Id)
            {
                return -1;
            }

            return 1;
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as Employee);
        }

        public override string ToString()
        {
            return this.ToString(onlyName: false);
        }

        public string ToString(bool onlyName)
        {
            var output = new StringBuilder();
            output.AppendLine(base.ToString());
            if (!onlyName)
            {
                output.AppendLine(string.Format("Salary: {0:C2}", this.Salary));
                output.Append(string.Format("Department: {0}", this.Department));                
            }

            return output.ToString();
        }
    }
}
