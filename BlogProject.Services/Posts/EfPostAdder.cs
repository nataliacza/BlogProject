using AutoMapper;
using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using BlogProject.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Services.Posts;

public class EfPostAdder : IPostAdder
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;



    public EfPostAdder(
        ApplicationDbContext dbContext,
        IMapper autoMapper,
        IHttpContextAccessor httpContextAccessor,
        UserManager<ApplicationUser> userManager)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public async Task<PostDto?> AddPost(AddPostDto addPostDto)
    {
        var userId = GetUserIdFromClaims();

        var currentUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

        var newPost = _autoMapper.Map<Post>(addPostDto);

        newPost.Author = currentUser;

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
