namespace PhonebookLibrary.Model
{
    using System.ComponentModel.DataAnnotations;
    
    public class Phone
    {
       public int Id { get; set; }

       [MaxLength(50)]
       public string Number { get; set; }

       public int ContactId { get; set; }

       public virtual Contact Contact { get; set; }
    }
}
