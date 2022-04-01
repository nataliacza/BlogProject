namespace BlogProject.Dtos.Posts;

public class PostDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Author { get; set; }
}
