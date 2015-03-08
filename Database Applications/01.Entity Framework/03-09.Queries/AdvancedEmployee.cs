namespace QueriesAndConcurentAccess
{
    using System.Data.Linq;
    using SoftUniDBContext;

    public class AdvancedEmployee : Employee
    {
        public AdvancedEmployee()
        {
            this.Territories = new EntitySet<Territory>();
        }

        public EntitySet<Territory> Territories { get; set; }
    }
}
