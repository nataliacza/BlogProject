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
            // var singlePost = _dbContext.Posts.Find(postId);

            //var singlePost = _dbContext.Posts
            //    .Select(x => new PostDto()
            //    {
            //        Id = x.Id,
            //    }).SingleOrDefault(x => x.Id == postId);

            var singlePost = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);

            if (singlePost == null)
            {
                throw new ArgumentException($"Post {postId} not found.");
            }
            
            _dbContext.Posts.Remove(singlePost);
            _dbContext.SaveChanges();

            return new PostDto
            {
                Id = singlePost.Id,
                Title = singlePost.Title,
                Content = singlePost.Content,
                Author = singlePost.Author,
                CreatedDate = singlePost.CreatedDate,
            };
        }
    }
}
