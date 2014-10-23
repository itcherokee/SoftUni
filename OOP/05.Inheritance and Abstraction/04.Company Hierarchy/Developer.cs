namespace Company
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Developer : RegularEmployee, IDeveloper
    {
        public Developer(string firstName, string lastName, uint id, decimal salary, Department department)
            : base(firstName, lastName, id, salary, department)
        {
        }

        public ICollection<OperationalItem> Projects
        {
            get
            {
                return this.Items.ToList().AsReadOnly();
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Position: Developer");
            output.AppendLine(base.ToString());
            output.AppendLine("Project(s):");
            if (this.Projects.Count == 0)
            {
                output.AppendLine("None");
            }
            else
            {
                output.AppendLine(string.Format("{0}", string.Join("\n", this.Projects)));
            }

            return output.ToString();
        }
    }
}
