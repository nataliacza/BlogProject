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
            // throw new NotImplementedException();

            //var newPost = ...;

            //_dbContext.Add(newPost);
            //_dbContext.SaveChanges();

            //return newPost;      // ??????????

            if (postDto == null)
            {
                throw new ArgumentNullException("Cannot be null!");
            }

            _dbContext.Add(postDto);
            _dbContext.SaveChanges();

            return postDto;

        }

    }
}





