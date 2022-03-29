using BlogProject.Dtos.Posts;


namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostAdder
    {
        PostDto AddPost(AddPostDto postDto);
    }
}
