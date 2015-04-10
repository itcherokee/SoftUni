namespace PhonebookLibrary.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Email
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
