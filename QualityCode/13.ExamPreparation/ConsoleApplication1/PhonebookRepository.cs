namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private OrderedSet<PhonebookEntry> sorted = new OrderedSet<PhonebookEntry>();
        private Dictionary<string, PhonebookEntry> dict = new Dictionary<string, PhonebookEntry>();
        private MultiDictionary<string, PhonebookEntry> multidict = new MultiDictionary<string, PhonebookEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> phones)
        {
            string name2 = name.ToLowerInvariant();
            PhonebookEntry entry; 
            bool flag = !this.dict.TryGetValue(name2, out entry);
            if (flag)
            {
                entry = new PhonebookEntry(); 
                entry.Name = name;
                entry.Phones = new SortedSet<string>(); 
                this.dict.Add(name2, entry);
                this.sorted.Add(entry);
            }

            foreach (var num in phones)
            {
                this.multidict.Add(num, entry);
            }

            entry.Phones.UnionWith(phones);
            return flag;
        }

        public int ChangePhone(string oldNumber, string newNumber)
        {
            var found = this.multidict[oldNumber].ToList();

            foreach (var entry in found)
            {
                entry.Phones.Remove(oldNumber);
                this.multidict.Remove(oldNumber, entry);
                entry.Phones.Add(newNumber); 
                this.multidict.Add(newNumber, entry);
            }

            return found.Count;
        }

        public IEnumerable<PhonebookEntry> ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException("startIndex", "Invalid range");
            }

            if (count < 0 || startIndex + count > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException("count", "Invalid range");
            }

            var listOfEntries = new PhonebookEntry[count];

            for (int index = startIndex; index <= startIndex + count - 1; index++)
            {
                var entry = this.sorted[index];
                listOfEntries[index - startIndex] = entry;
            }

            return listOfEntries;
        }
    }
}