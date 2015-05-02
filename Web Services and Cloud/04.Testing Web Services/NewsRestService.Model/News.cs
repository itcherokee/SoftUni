namespace NewsRestService.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10), MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        public override string ToString()
        {
            return this.Title + " " + this.Content + " (" + this.PublishDate + ")";
        }
    }
}
