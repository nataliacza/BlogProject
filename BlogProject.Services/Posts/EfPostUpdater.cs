using AutoMapper;
using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Services.Posts;

public class EfPostUpdater : IPostUpdater
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _autoMapper;


    public EfPostUpdater(
        ApplicationDbContext dbContext,
        IMapper autoMapper)
    {
        _dbContext = dbContext;
        _autoMapper = autoMapper;
    }

    public async Task<PostDto> UpdatePost(int postId, UpdatePostDto updatePostDto)
    {
        var postFromDb = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == postId);

        if (postFromDb == null)
        {
            return null;
        }

        var mappedPost = _autoMapper.Map(updatePostDto, postFromDb);

        _dbContext.Posts.Update(postFromDb);
        
        await _dbContext.SaveChangesAsync();

        var result = _autoMapper.Map<PostDto>(postFromDb);

        return result;
    }
}
