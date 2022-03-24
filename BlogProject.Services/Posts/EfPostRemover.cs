using System;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using BlogProject.Services.Interfaces.Posts;


namespace BlogProject.Services.Posts
{
    public class EfPostRemover: IPostRemover
    {
        private readonly ApplicationDbContext _dbContext;

        public EfPostRemover(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PostDto RemovePost(int postId)
        {
            var singlePost = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);

            if (singlePost == null)
            {
                throw new ArgumentException($"Post with ID {postId} not exist.");
            }

            _dbContext.Remove(postId);

            return singlePost;
            
        }
    }
}
