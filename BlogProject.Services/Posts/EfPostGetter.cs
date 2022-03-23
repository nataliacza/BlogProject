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

        public IEnumerable<PostDto> Get()
        {
            return _dbContext.Posts
                .Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate,
                    Author = x.Author
                });
        }

        public PostDto Get(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(
                x => x.Id == id
                );

            return new PostDto(post);
        }
    }
}