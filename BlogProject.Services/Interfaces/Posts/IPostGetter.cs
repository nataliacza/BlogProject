using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostGetter
    {
        List<PostDto> GetPost();
        PostDto GetPost(int id);
    }
}
