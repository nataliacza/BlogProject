using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostRemover
    {
        Task<PostDto> RemovePost(int postId);
    }
}
