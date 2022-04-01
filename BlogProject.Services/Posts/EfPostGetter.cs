using AutoMapper;
using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Services.Posts;


public class EfPostGetter: IPostGetter
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;

    public EfPostGetter(
        ApplicationDbContext dbContext,
        IMapper autoMapper)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
    }

    public async Task<IEnumerable<PostDto>> GetAllPosts()
    {
        var allPostsFromDb = await _dbContext.Posts.ToArrayAsync();

        var allMappedPosts = _autoMapper.Map<IEnumerable<PostDto>>(allPostsFromDb);

        return allMappedPosts;
    }

    public async Task<PostDto> GetSinglePost(int? postId)
    {
        var getSinglePost = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == postId);

        if (getSinglePost == null)
        {
            return null;
        }

        var singleMappedPost = _autoMapper.Map<PostDto>(getSinglePost);

        return singleMappedPost;
    }
}

