using System.ComponentModel.DataAnnotations;

namespace NewsDatabase.Model
{
    public class News
    {
        public int NewsId { get; set; }

        [ConcurrencyCheck]
        public string Content { get; set; }
    }
}
