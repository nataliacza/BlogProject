using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Services.Posts
{
    public class EfPostGetter: IPostGetter
    {
        private readonly ApplicationDbContext _dbContext;

        public EfPostGetter(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PostDto>> GetAllPosts()
        {
            var posts = await _dbContext.Posts
                .Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    Author = x.Author
                }).ToArrayAsync();

            return posts;
        }

        public PostDto GetSinglePost(int postId)
        {
            var singlePost = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);

            if (singlePost == null)
            {
                return null;
            }

            return new PostDto
            {
                Id = singlePost.Id,
                Title = singlePost.Title,
                Content = singlePost.Content,
                CreatedDate = singlePost.CreatedDate,
                Author = singlePost.Author
            };
        }
    }
}
