using AutoMapper;
using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using BlogProject.Database.Models;
using Microsoft.AspNetCore.Http;


namespace BlogProject.Services.Posts;

public class EfPostAdder : IPostAdder
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EfPostAdder(
        ApplicationDbContext dbContext,
        IMapper autoMapper,
        IHttpContextAccessor httpContextAccessor
        )
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<PostDto?> AddPost(AddPostDto addPostDto)
    {
        var userId = GetUserIdFromClaims();

        var newPost = _autoMapper.Map<Post>(addPostDto);

        newPost.AuthorId = userId;

        _dbContext.Posts.Add(newPost);
        await _dbContext.SaveChangesAsync();

        var newPostMapped = _autoMapper.Map<PostDto>(newPost);

        return newPostMapped;
    }


    private string GetUserIdFromClaims()
    {
        return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
    }

}
