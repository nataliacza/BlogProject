using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;


namespace BlogProject.Services.Posts
{
    public class EfPostUpdater : IPostUpdater
    {
        private readonly ApplicationDbContext _dbContext;

        public EfPostUpdater(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PostDto UpdatePost(int postId, UpdatePostDto updatePostDto)
        {
            var existingPost = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);

            if (existingPost == null)
            {
                return null;
            }

            existingPost.Title = updatePostDto.Title;
            existingPost.Content = updatePostDto.Content;

            _dbContext.Posts.Update(existingPost);
            _dbContext.SaveChanges();

            return new PostDto
            {
                Id = existingPost.Id,
                Title = existingPost.Title,
                Content = existingPost.Content,
                Author = existingPost.Author,
                CreatedDate = existingPost.CreatedDate,
            };
        }
    }
}
