using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set;  }

        public Post()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
