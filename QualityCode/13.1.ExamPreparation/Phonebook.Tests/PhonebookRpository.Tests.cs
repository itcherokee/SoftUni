using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Phonebook.Tests
{
    [TestClass]
    public class PhonebookRpositoryTests
    {
        [TestMethod]
        public void TestNumberAdditionContainingNoAnyPrefixesAndNoSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "123" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +359123]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingSingleZeroInFrontWhiteSpacesAndNotAllowedSymbolsAsSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "0883 / 456-789" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +359883456789]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingSingleZeroInFrontAndWhiteSpacesAsSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "0888 88 99 00" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +359888889900]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingDashesAsSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "888-88-99-00" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +359888889900]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingFullCountryCodeInFrontWhiteSpacesAndNotAlowedSymbolsAsSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "00359 (888) 41-80-12" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +359888418012]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingLeadingZeroAsCityCodeInFrontWhiteSpacesAndNotAlowedSymbolsAsSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "(02) 981 22 33" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +35929812233]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingShortCountryCodeWithPlusSymbolAndNoSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "+359527734522" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +359527734522]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingShortCountryCodeWithPlusSymbolWhiteSpacesAndNotAllowedSymbolsAsSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "+359 (888) 41-80-12" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +359888418012]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingOtherCountryShortCountryCodeWithPlusSymbolWhiteSpacesAndNotAllowedSymbolsAsSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "(+1) 123-456-789" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +1123456789]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingOtherCountryLongCountryCodeAndWhiteSpacesAsSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "001 123 456 789" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +1123456789]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingOtherCountryLongCountryCodeNoSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "001123456789" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +1123456789]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestNumberAdditionContainingOtherCountryShortCountryCodeNoSeparators()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "+1123456789" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +1123456789]", phoneEntry.ToString());
        }

        [TestMethod]
        public void TestAddingSinglePhonebookEntryWithTwoPhoneNumbers()
        {
            var phonebook = new PhonebookRepository();
            phonebook.AddPhone("Mike", new[] { "+1123456789" });
            var actualPhone = phonebook.ListEntries(0, 1);
            PhonebookEntry phoneEntry = phonebook.ListEntries(0, 1).FirstOrDefault();
            Assert.AreEqual("[Mike: +1123456789]", phoneEntry.ToString());
        }


    }
}
