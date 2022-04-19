using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlogProject.Database.Models;

public class Post
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    [StringLength(1000)]
    public string Content { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;


    [ForeignKey("User")]
    public string AuthorId { get; set; }
    public virtual ApplicationUser Author { get; set; }

}
