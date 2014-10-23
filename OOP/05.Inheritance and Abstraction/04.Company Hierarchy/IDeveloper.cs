namespace Company
{
    using System.Collections.Generic;

    public interface IDeveloper : IRegularEmployee
    {
        ICollection<OperationalItem> Projects { get; }
    }
}