using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Interfaces.Posts;

public interface IPostAdder
{
    Task<PostDto> AddPost(AddPostDto postDto);
}
