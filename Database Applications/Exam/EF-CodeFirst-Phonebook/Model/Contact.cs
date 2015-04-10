namespace PhonebookLibrary.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Contact
    {
        private ICollection<Email> emails;
        private ICollection<Phone> phones;

        public Contact()
        {
            this.emails = new HashSet<Email>();
            this.phones = new HashSet<Phone>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Position { get; set; }

        [MaxLength(50)]
        public string Company { get; set; }

        [MaxLength(50)]
        public string SiteUrl { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<Email> Emails
        {
            get
            {
                return this.emails;
            }

            set
            {
                this.emails = value;
            }
        }

        public virtual ICollection<Phone> Phones
        {
            get
            {
                return this.phones;
            }

            set
            {
                this.phones = value;
            }
        }
    }
}
