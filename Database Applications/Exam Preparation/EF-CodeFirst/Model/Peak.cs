namespace EFCodeFirst.Model
{
    using System.ComponentModel.DataAnnotations;

    public class Peak
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Elevation { get; set; }

        public int MontainId { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
