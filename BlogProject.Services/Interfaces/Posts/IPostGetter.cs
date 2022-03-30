using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostGetter
    {
        Task<IEnumerable<PostDto>> GetAllPosts();
        PostDto GetSinglePost(int postId);
    }
}
