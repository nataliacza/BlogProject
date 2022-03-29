using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostGetter
    {
        IEnumerable<PostDto> GetAllPosts();
        PostDto GetSinglePost(int postId);
    }
}
