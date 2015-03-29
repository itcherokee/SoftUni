namespace ATM.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TransactionHistory
    {
        public int Id { get; set; }

        [Required, MaxLength(10), MinLength(10)]
        [Column(TypeName = "char")]
        public string CardNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}
