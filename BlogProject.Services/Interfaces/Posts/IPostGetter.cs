using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Interfaces.Posts;

public interface IPostGetter
{
    Task<IEnumerable<PostDto>> GetAllPosts();
    Task<PostDto?> GetSinglePost(int? postId);
}
