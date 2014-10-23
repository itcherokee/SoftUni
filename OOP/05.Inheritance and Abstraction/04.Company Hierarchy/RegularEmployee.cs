namespace Company
{
    using System;
    using System.Collections.Generic;

    public abstract class RegularEmployee : Employee, IRegularEmployee
    {
        private readonly HashSet<OperationalItem> items;

        protected RegularEmployee(string firstName, string lastName, uint id, decimal salary, Department department)
            : base(firstName, lastName, id, salary, department)
        {
            this.items = new HashSet<OperationalItem>();
        }

        protected ICollection<OperationalItem> Items
        {
            get
            {
                return this.items;
            }
        }

        public void AddItem(OperationalItem process)
        {
            if (process == null)
            {
                throw new ArgumentNullException("process", "Process cannot be null.");
            }

            if (this.items.Contains(process))
            {
                throw new ArgumentException("This process is already in the list.");
            }

            this.Items.Add(process);
        }
    }
}
