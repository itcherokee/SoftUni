using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook;

namespace PhonebookSystem.Tests
{
    [TestClass]
    public class PhonebookRepositoryTests
    {
        [TestMethod]
        public void ListPhonebookNumbersAllPossiblePhoneNumbersSyntax()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Katia",
                new[]
                {
                    "(02) 111 11 22", "123", "(+1) 123 456 789", "0883 / 456-789", "0888 88 99 00", "888-88-99-00",
                    "+359 (888) 41-80-12", "00359 (888) 41-80-12", "+359527734522"
                });

        }
    }
}
