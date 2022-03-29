using BlogProject.Dtos.Posts;


namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostUpdater
    {
        UpdatePostDto UpdatePost(int id, UpdatePostDto postDto);
    }
}
