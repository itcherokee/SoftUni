namespace Phonebook
{
    using System;
    using System.Collections.Generic;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        public string Name { get; set; }

        public SortedSet<string> PhoneNumbers { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}: {1}]", this.Name, string.Join(", ", this.PhoneNumbers));
        }

        public int CompareTo(PhonebookEntry otherEntry)
        {
            return string.Compare(this.Name, otherEntry.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
