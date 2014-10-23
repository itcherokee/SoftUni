namespace Company
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public SalesEmployee(string firstName, string lastName, uint id, decimal salary, Department department)
            : base(firstName, lastName, id, salary, department)
        {
        }

        public ICollection<OperationalItem> Sales
        {
            get
            {
                return this.Items.ToList().AsReadOnly();
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Position: Sales Employee");
            output.AppendLine(base.ToString());
            output.Append("Sales: ");
            if (this.Sales.Count == 0)
            {
                output.AppendFormat("{0:C2}\n", 0);
            }
            else
            {
                output.AppendLine(string.Format("{0}", string.Join(string.Empty, this.Sales)));
            }

            return output.ToString();
        }
    }
}
