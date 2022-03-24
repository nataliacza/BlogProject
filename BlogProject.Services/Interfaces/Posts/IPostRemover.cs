using BlogProject.Dtos.Posts;


namespace BlogProject.Services.Interfaces.Posts
{
    public interface IPostRemover
    {
        // here
        PostDto RemovePost(int postId);
    }
}
