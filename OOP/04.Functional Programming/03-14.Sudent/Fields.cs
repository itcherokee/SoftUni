namespace University
{
    using System;

    [Flags]
    public enum Fields
    {
        First = 0x01,
        Last = 0x02,
        Age = 0x04,
        Fn = 0x08,
        Tel = 0x10,
        Email = 0x20,
        Group = 0x40,
        Marks = 0x80
    }
}
