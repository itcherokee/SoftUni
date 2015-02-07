namespace Phonebook.Contracts
{
    using System.Collections.Generic;

    internal interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        IEnumerable<PhonebookEntry> ListEntries(int startIndex, int count);
    }
}