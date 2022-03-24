using BlogProject.Dtos.Posts;


namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostUpdater
    {
        // ... Update(post id, ...);
        object UpdatePost();
    }
}
