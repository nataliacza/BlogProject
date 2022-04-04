using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Interfaces.Posts;

public interface IPostUpdater
{
    Task<PostDto?> UpdatePost(int? postId, UpdatePostDto postDto);
}
