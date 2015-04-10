namespace PhonebookLibrary.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Data;
    using Model;

    internal sealed class Configuration : DbMigrationsConfiguration<PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhonebookContext context)
        {
            if (!context.Contacts.Any())
            {
                var peterEmails = new List<Email>
                {
                    new Email {Address = "peter@gmail.com"},
                    new Email {Address = "peter_ivanov@yahoo.com"}
                };

                var AngieEmails = new List<Email>
                {
                    new Email {Address = "info@angiestanton.com"}
                };

                var peterPhones = new List<Phone>
                {
                    new Phone {Number = "+359 2 22 22 22"},
                    new Phone {Number = "+359 88 77 88 99"}
                };

                var mariaPhones = new List<Phone>
                {
                    new Phone {Number = "+359 22 33 44 55"}
                };

                var contacts
                    = new List<Contact>
                {
                    new Contact
                    {
                        Name = "Peter Ivanov",
                        Position = "CTO", 
                        Company = "Smart Ideas", 
                        SiteUrl = "http://blog.peter.com", 
                        Notes = "Friend from school",
                        Emails = peterEmails,
                        Phones = peterPhones
                    },
                    new Contact
                    {
                        Name = "Maria",
                        Phones = mariaPhones
                    },
                    new Contact
                    {
                        Name = "Angie Stanton", 
                        SiteUrl = "http://angiestanton.com",
                        Emails = AngieEmails
                    },
                };

                foreach (var contact in contacts)
                {
                    context.Contacts.Add(contact);
                }
            
            }
        }
    }
}
