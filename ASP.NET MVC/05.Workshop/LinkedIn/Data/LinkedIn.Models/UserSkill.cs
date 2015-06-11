namespace LinkedIn.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserSkill
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int SklillId { get; set; }

        public virtual Skill Skill { get; set; }

        public virtual ICollection<Endorcement> Endorcements { get; set; }
    }
}
