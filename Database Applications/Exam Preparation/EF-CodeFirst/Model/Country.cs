namespace EFCodeFirst.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country
    {
        private ICollection<Mountain> mountains;

        public Country()
        {
            this.mountains = new HashSet<Mountain>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(2), MinLength(2)]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Mountain> Mountains
        {
            get
            {
                return this.mountains;
            }

            set
            {
                this.mountains = value;
            }
        }
    }
}
