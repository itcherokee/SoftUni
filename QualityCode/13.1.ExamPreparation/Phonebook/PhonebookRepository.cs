namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly string defaultCountryCode;
        private readonly OrderedSet<PhonebookEntry> sortedEntries = new OrderedSet<PhonebookEntry>();
        private readonly Dictionary<string, PhonebookEntry> entries = new Dictionary<string, PhonebookEntry>(StringComparer.OrdinalIgnoreCase);
        private readonly MultiDictionary<string, PhonebookEntry> allPhoneNumbers = new MultiDictionary<string, PhonebookEntry>(false);

        public PhonebookRepository(string defaultCountryCode = "+359")
        {
            this.defaultCountryCode = defaultCountryCode;
        }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            var canonicalPhoneNumbers = phoneNumbers.ToArray();
            for (int index = 0; index < canonicalPhoneNumbers.Length; index++)
            {
                canonicalPhoneNumbers[index] = this.ConvertPhoneToCanonicalForm(canonicalPhoneNumbers[index]);
            }

            PhonebookEntry entry;
            bool isPhonebookEntryExists = !this.entries.TryGetValue(name, out entry);
            if (isPhonebookEntryExists)
            {
                entry = new PhonebookEntry { Name = name, PhoneNumbers = new SortedSet<string>() };
                this.entries.Add(name, entry);
                this.sortedEntries.Add(entry);
            }

            foreach (var phoneNumber in canonicalPhoneNumbers)
            {
                this.allPhoneNumbers.Add(phoneNumber, entry);
            }

            entry.PhoneNumbers.UnionWith(canonicalPhoneNumbers);

            return isPhonebookEntryExists;
        }

        public int ChangePhone(string oldPhoneNumber, string newPhoneNumber)
        {
            var canonicalOldPhoneNumber = this.ConvertPhoneToCanonicalForm(oldPhoneNumber);
            var entriesWithOldPhoneNumber = this.allPhoneNumbers[canonicalOldPhoneNumber].ToList();
            var canonicalNewPhoneNumber = this.ConvertPhoneToCanonicalForm(newPhoneNumber);
            foreach (var entry in entriesWithOldPhoneNumber)
            {
                entry.PhoneNumbers.Remove(canonicalOldPhoneNumber);
                this.allPhoneNumbers.Remove(canonicalOldPhoneNumber, entry);
                entry.PhoneNumbers.Add(canonicalNewPhoneNumber);
                this.allPhoneNumbers.Add(canonicalNewPhoneNumber, entry);
            }

            return entriesWithOldPhoneNumber.Count;
        }

        public IEnumerable<PhonebookEntry> ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("startIndex", "Invalid range");
            }

            if (count < 0 || startIndex + count > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("count", "Invalid range");
            }

            var listedPhonebookEntries = new PhonebookEntry[count];

            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                listedPhonebookEntries[i - startIndex] = this.sortedEntries[i];
            }

            return listedPhonebookEntries;
        }

        private string ConvertPhoneToCanonicalForm(string phoneNumber)
        {
            var canonicalPhoneNumber = new StringBuilder(phoneNumber.Length);
            foreach (char symbol in phoneNumber)
            {
                if (char.IsDigit(symbol) || (symbol == '+'))
                {
                    canonicalPhoneNumber.Append(symbol);
                }
            }

            if (canonicalPhoneNumber.Length >= 2 && canonicalPhoneNumber[0] == '0' && canonicalPhoneNumber[1] == '0')
            {
                canonicalPhoneNumber.Remove(0, 1);
                canonicalPhoneNumber[0] = '+';
            }

            while (canonicalPhoneNumber.Length > 0 && canonicalPhoneNumber[0] == '0')
            {
                canonicalPhoneNumber.Remove(0, 1);
            }

            if (canonicalPhoneNumber.Length > 0 && canonicalPhoneNumber[0] != '+')
            {
                canonicalPhoneNumber.Insert(0, this.defaultCountryCode);
            }

            return canonicalPhoneNumber.ToString();
        }
    }
}
