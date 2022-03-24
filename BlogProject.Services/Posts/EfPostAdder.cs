using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;

namespace BlogProject.Services.Posts
{
    public class EfPostAdder : IPostAdder
    {
        private readonly ApplicationDbContext _dbContext;

        public EfPostAdder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PostDto AddPost(PostDto postDto)
        {
            var newPost = _dbContext.Posts.Add;  // ??????????

            _dbContext.Add(newPost);
            _dbContext.SaveChanges();

            return default;      // ??????????
        }

    }
}





