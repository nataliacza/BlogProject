using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set;  }
        public string Author { get; set; }

        public Posts()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
