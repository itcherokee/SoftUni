namespace Company
{
    using System;

    internal interface ISale : IOperationalItem
    {
        DateTime Date { get; set; }

        decimal Price { get; set; }
    }
}