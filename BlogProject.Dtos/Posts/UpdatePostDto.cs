using System.ComponentModel.DataAnnotations;

namespace BlogProject.Dtos.Posts;

public class UpdatePostDto
{
    [MaxLength(50)]
    public string Title { get; set; }

    [MaxLength(1000)]
    public string Content { get; set; }
}
