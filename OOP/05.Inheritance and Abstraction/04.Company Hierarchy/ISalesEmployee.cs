namespace Company
{
    using System.Collections.Generic;

    public interface ISalesEmployee : IRegularEmployee
    {
        ICollection<OperationalItem> Sales { get; }
    }
}