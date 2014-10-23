namespace Company
{
    using System;

    internal interface IProject : IOperationalItem
    {
        DateTime StartDate { get; set; }

        ProjectState State { get; }

        string Details { get; set; }

        void CloseProject();
    }
}