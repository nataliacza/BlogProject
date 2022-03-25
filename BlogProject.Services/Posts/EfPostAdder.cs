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

            PostDto newPost = new PostDto()
            {
                Id = postDto.Id,
                Title = postDto.Title,
                Content = postDto.Content,
                CreatedDate = DateTime.UtcNow,
                Author = postDto.Author,
            };

            //if (postDto == null)
            //{
            //    throw new ArgumentNullException("Cannot be null!");
            //}

            _dbContext.Add(newPost);
            _dbContext.SaveChanges();

            return newPost;

        }

    }
}





