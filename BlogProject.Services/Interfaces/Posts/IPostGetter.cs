using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostGetter
    {
        IEnumerable<PostDto> GetPosts();
        PostDto GetSinglePost(int id);
    }
}
