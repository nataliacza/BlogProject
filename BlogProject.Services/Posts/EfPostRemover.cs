using AutoMapper;
using BlogProject.Database;
using BlogProject.Dtos.Posts;
using BlogProject.Services.Interfaces.Posts;


namespace BlogProject.Services.Posts
{
    public class EfPostRemover: IPostRemover
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _autoMapper;

        public EfPostRemover(
            ApplicationDbContext dbContext,
            IMapper autoMapper)
        {
            _dbContext = dbContext;
            _autoMapper = autoMapper;
        }

        public PostDto RemovePost(int postId)
        {
            var singlePost = _dbContext.Posts.FirstOrDefault(x => x.Id == postId);

            var removedMappedPost = _autoMapper.Map<PostDto>(singlePost);

            if (singlePost == null)
            {
                return null;
            }
            
            _dbContext.Posts.Remove(singlePost);
            _dbContext.SaveChanges();

            return removedMappedPost;
        }
    }
}
