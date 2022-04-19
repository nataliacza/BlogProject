using BlogProject.Database.Models;
using BlogProject.Dtos.Posts;
using BlogProject.Dtos.Accounts;


namespace BlogProject.Services.Interfaces.Posts;

public interface IPostAdder
{
    Task<PostDto?> AddPost(AddPostDto postDto);
}
