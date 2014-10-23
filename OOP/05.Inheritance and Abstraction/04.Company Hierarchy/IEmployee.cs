namespace Company
{
    using System;

    public interface IEmployee : IPerson, IComparable<Employee>, IComparable
    {
        decimal Salary { get; set; }

        Department Department { get; set; }
    }
}