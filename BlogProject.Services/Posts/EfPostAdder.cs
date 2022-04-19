using AutoMapper;
using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using BlogProject.Database.Models;
using BlogProject.Services.Interfaces.Accounts;

namespace BlogProject.Services.Posts;

public class EfPostAdder : IPostAdder
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;
    private readonly IContextUserGetter _contextUserGetter;

    public EfPostAdder(
        ApplicationDbContext dbContext,
        IMapper autoMapper,
        IContextUserGetter contextUserGetter
        )
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
        _contextUserGetter = contextUserGetter;
    }

    public async Task<PostDto?> AddPost(AddPostDto addPostDto)
    {
        var userId = _contextUserGetter.GetUserId();

        var newPost = _autoMapper.Map<Post>(addPostDto);

        newPost.AuthorId = userId;

        _dbContext.Posts.Add(newPost);
        await _dbContext.SaveChangesAsync();

        var newPostMapped = _autoMapper.Map<PostDto>(newPost);

        return newPostMapped;
    }
}
