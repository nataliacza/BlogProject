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

        public IEnumerable<PostDto> GetAllPosts()
        {
            var allPosts = _dbContext.Posts
                .Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    Author = x.Author
                }).ToArray();

            return allPosts;
        }

        public PostDto GetSinglePost(int postId)
        {
            //var singlePost1 = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);

            var singlePost = _dbContext.Posts
                .Select(x => new PostDto 
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    Author = x.Author
                }).SingleOrDefault(x => x.Id == postId);

            if (singlePost == null)
            {
                throw new ArgumentException($"Post with ID {postId} not exist.");
            }

            return singlePost;
        }
    }
}