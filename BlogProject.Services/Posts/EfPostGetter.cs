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
            // var singlePost = _dbContext.Posts.Where(x => x.Id == postId).FirstOrDefault();
            // var singlePost = _dbContext.Posts.SingleOrDefault(x => x.Id == postId);
            // var singlePost = _dbContext.Posts.Find(postId);

            //var singlePost = _dbContext.Posts
            //    .Where(x => x.Id == postId)
            //    .Select(x => new PostDto
            //    {
            //        Id = x.Id,
            //        Title = x.Title,
            //        Content = x.Content,
            //        CreatedDate = x.CreatedDate,
            //        Author = x.Author
            //    })
            //    .FirstOrDefault();

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