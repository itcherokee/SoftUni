namespace ATM.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CardAccount
    {
        public int Id { get; set; }

        [Required, MaxLength(10), MinLength(10)]
        [Column(TypeName = "char")]
        public string CardNumber { get; set; }

        [Required, MaxLength(4), MinLength(4)]
        [Column(TypeName = "char")]
        public string CardPIN { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal CardCash { get; set; }
    }
}
