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

            var post = _dbContext.Posts
                .Select(x => new PostDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    Author = x.Author
                }).SingleOrDefault();    //?????????????????

            if (post == null)
            {
                throw new ArgumentException($"Post Id: {postId} not exist.");
            }

            _dbContext.Update(post);
            _dbContext.SaveChanges();

            return post;

        }
    }
}