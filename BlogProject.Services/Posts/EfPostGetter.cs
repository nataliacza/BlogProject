using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;


namespace BlogProject.Services.Posts
{
    public class EfPostGetter: IPostGetter
    {
        private readonly ApplicationDbContext _dbContext;

        public EfPostGetter(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PostDto> GetPosts()
        {
            var allPosts = _dbContext.Posts
                .Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    Author = x.Author
                });

            return allPosts;
        }

        public IEnumerable<PostDto> GetSinglePost(int postId)
        {
            var singlePost = _dbContext.Posts.SingleOrDefault(
                x => x.Id == postId
                );

            // here we need to cover somehow if ID is null

            return singlePost;
        }
    }
}