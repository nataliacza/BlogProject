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

        public PostDto UpdatePost(int postId, PostDto postDto)
        {
            //var post = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);

            var existingID = _dbContext.Posts.Find(postId);

            if (existingID == null)
            {
                throw new KeyNotFoundException($"Post Id: {postId} not exist.");
            }

            PostDto updatedItem = new PostDto
            {
                Title = postDto.Title,
                Content = postDto.Content,
            };

            _dbContext.Update(updatedItem);
            _dbContext.SaveChanges();

            return updatedItem;

        }
    }
}