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

        public UpdatePostDto UpdatePost(int postId, UpdatePostDto postDto)
        {
            var existingPost = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);

            if (existingPost == null)
            {
                return null;
            }

            UpdatePostDto updatedDetails = new UpdatePostDto
            {
                Title = postDto.Title,
                Content = postDto.Content,
            };

            existingPost.Title = postDto.Title;
            existingPost.Content = postDto.Content;

            _dbContext.Posts.Update(existingPost);
            _dbContext.SaveChanges();

            return updatedDetails;

        }
    }
}