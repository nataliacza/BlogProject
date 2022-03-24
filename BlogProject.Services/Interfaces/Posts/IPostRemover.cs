using BlogProject.Dtos.Posts;


namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostRemover
    {
        PostDto RemovePost(int postId);
    }
}
