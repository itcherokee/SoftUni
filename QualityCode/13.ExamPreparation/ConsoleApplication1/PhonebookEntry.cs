namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        public string Name { get; set; }

        public SortedSet<string> Phones { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder(this.Phones.Count * 10);
            output.Append('[' + this.Name + ": ");
            output.Append(string.Join(", ", this.Phones));
            output.Append(']');

            return output.ToString();
        }

        public int CompareTo(PhonebookEntry otherEntry)
        {
            return string.Compare(this.Name, otherEntry.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}