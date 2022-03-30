using BlogProject.Services.Interfaces.Posts;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using BlogProject.Database.Models;

namespace BlogProject.Services.Posts
{
    public class EfPostAdder : IPostAdder
    {
        private readonly ApplicationDbContext _dbContext;

        public EfPostAdder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PostDto AddPost(AddPostDto postDto)
        {
            var newPost = new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                Author = postDto.Author,
                CreatedDate = DateTime.UtcNow,
            };

            if (postDto == null)
            {
                return null;
            }

            _dbContext.Posts.Add(newPost);
            _dbContext.SaveChanges();

            return new PostDto 
            {
                Id = newPost.Id,
                Title = newPost.Title,
                Content = newPost.Content,
                Author = newPost.Author,
                CreatedDate = newPost.CreatedDate,
            };

        }

    }
}
