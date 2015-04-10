namespace PhonebookLibrary.Data
{
    using System.Data.Entity;

    using Migrations;
    using Model;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("Phonebook")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>());
        }

        public virtual IDbSet<Contact> Contacts { get; set; }

        public virtual IDbSet<Email> Emails { get; set; }

        public virtual IDbSet<Phone> Phones { get; set; }
    }
}