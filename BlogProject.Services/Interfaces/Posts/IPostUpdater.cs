using BlogProject.Dtos.Posts;


namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostUpdater
    {
        PostDto UpdatePost(int id, UpdatePostDto postDto);
    }
}
