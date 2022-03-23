using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostGetter
    {
        IEnumerable<PostDto> Get();
        PostDto Get(int id);
    }
}
