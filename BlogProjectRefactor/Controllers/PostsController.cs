using BlogProject.Dtos.Posts;
using BlogProject.Services.Interfaces.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogProjectRefactor.Controllers
{
    [Route("api/posts")]
    public class PostsContoller : ControllerBase
    {
        private readonly IPostGetter _postGetter;
        private readonly IPostAdder _postAdder;
        private readonly IPostRemover _postRemover;
        private readonly IPostUpdater _postUpdater;
        
        public PostsContoller(
            IPostGetter postGetter,
            IPostAdder postAdder, 
            IPostRemover postRemover, 
            IPostUpdater postUpdater)
        {
            _postGetter = postGetter;
            _postAdder = postAdder;
            _postRemover = postRemover;
            _postUpdater = postUpdater;
        }

        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            var posts = await _postGetter.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public IActionResult GetPostDetail(int postId)
        {
            var postDetail = _postGetter.GetSinglePost(postId);
            return Ok(postDetail);
        }

        [HttpDelete("{postId}")]
        public IActionResult RemovePost(int postId)
        {
            var removedPost = _postRemover.RemovePost(postId);
            return Ok(removedPost);
        }

        [HttpPost]
        public IActionResult AddPost([FromBody] AddPostDto addPostDto)
        {
            var addPost = _postAdder.AddPost(addPostDto);
            return Ok(addPost);
        }

        [HttpPut("{postId}")]
        public IActionResult UpdatePost(int postId, [FromBody] UpdatePostDto updatePostDto)
        {
            var updatePost = _postUpdater.UpdatePost(postId, updatePostDto);
            return Ok(updatePost);
        }
    }
}
