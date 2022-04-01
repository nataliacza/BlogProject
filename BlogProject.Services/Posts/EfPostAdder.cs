using AutoMapper;
using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using BlogProject.Database.Models;

namespace BlogProject.Services.Posts;

public class EfPostAdder : IPostAdder
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfPostAdder(
        ApplicationDbContext dbContext,
        IMapper autoMapper)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
    }

    public async Task<PostDto> AddPost(AddPostDto addPostDto)
    {
        var newPost = _autoMapper.Map<Post>(addPostDto);

        if (newPost == null)
        {
            return null;
        }

        _dbContext.Posts.Add(newPost);

        await _dbContext.SaveChangesAsync();

        var newPostMapped = _autoMapper.Map<PostDto>(newPost);

        return newPostMapped;
    }
}
