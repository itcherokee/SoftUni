namespace PhonebookLibrary
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data;

    public class ListContacts
    {
        public static void Main()
        {
            using (var context = new PhonebookContext())
            {
                var contacts = context.Contacts
                    .Include(p => p.Phones)
                    .Include(e => e.Emails)
                    .Select(c => new
                    {
                        c.Name,
                        Phones = c.Phones.Select(p => p.Number).ToList(),
                        Emails = c.Emails.Select(p => p.Address).ToList(),
                    });

                foreach (var contact in contacts)
                {
                    Console.WriteLine("Name: {0}", contact.Name);
                    Console.WriteLine("\tPhones: {0}", string.Join(", ", contact.Phones));
                    Console.WriteLine("\tEmails: {0}", string.Join(", ", contact.Emails));
                }
            }
        }
    }
}
