using AutoMapper;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using BlogProject.Services.Interfaces.Posts;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Services.Posts
{
    public class EfPostRemover: IPostRemover
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _autoMapper;

        public EfPostRemover(
            ApplicationDbContext dbContext,
            IMapper autoMapper)
        {
            _dbContext = dbContext;
            _autoMapper = autoMapper;
        }

        public async Task<PostDto> RemovePost(int? postId)
        {
            var singlePost = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == postId);

            if (singlePost == null)
            {
                string message = $"Post ID {postId} not found!";
                throw new ArgumentNullException(message);
            }

            var removedMappedPost = _autoMapper.Map<PostDto>(singlePost);

            _dbContext.Posts.Remove(singlePost);
            await _dbContext.SaveChangesAsync();

            return removedMappedPost;
        }
    }
}
