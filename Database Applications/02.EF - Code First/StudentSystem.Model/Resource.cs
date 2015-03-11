namespace StudentSystem.Model
{
    using System.ComponentModel.DataAnnotations;
    using Enumerations;

    public class Resource
    {
        public int ResourceId { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        public string Link { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
