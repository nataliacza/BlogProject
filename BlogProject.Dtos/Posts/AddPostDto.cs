using System.ComponentModel.DataAnnotations;

namespace BlogProject.Dtos.Posts;

public class AddPostDto
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }

    [MaxLength(1000)]
    public string Content { get; set; }

    public string Author { get; set; }
}
