using BlogProject.Dtos.Posts;
using BlogProject.Services.Interfaces.Posts;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectRefactor.Controllers
{
    [Route("api/posts")]
    public class PostsContoller : ControllerBase
    {
        private readonly IPostGetter _postGetter;
        private readonly IPostAdder _postAdder;
        private readonly IPostRemover _postRemover;
        private readonly IPostUpdater _postUpdater;
        
        public PostsContoller(IPostGetter postGetter, IPostAdder postAdder, IPostRemover postRemover, IPostUpdater postUpdater)
        {
            _postGetter = postGetter;
            _postAdder = postAdder;
            _postRemover = postRemover;
            _postUpdater = postUpdater;
        }

        //GET POST LIST
        [HttpGet]
        public IActionResult GetPost()
        {
            var posts = _postGetter.GetAllPosts();
            return Ok(posts);
        }

        //GET SINGLE POST
        [HttpGet("{postId}")]
        public IActionResult GetPostDetail(int postId)
        {
            var postDetail = _postGetter.GetSinglePost(postId);

            //if (postDetail == null)
            //{
            //    return NotFound();
            //}

            return Ok(postDetail);
        }

        //REMOVE A POST
        [HttpDelete("{postId}")]
        public IActionResult RemovePost(int postId)
        {
            var removedPost = _postRemover.RemovePost(postId);
            return Ok(removedPost);
        }

        //CREATE NEW POST
        [HttpPost]
        public IActionResult AddPost([FromBody] AddPostDto postDto)
        {
            var addPost = _postAdder.AddPost(postDto);
            return Ok(addPost);
        }

        //UPDATE A POST
        [HttpPut("{postId}")]
        public IActionResult UpdatePost(int postId, [FromBody] UpdatePostDto postDto)
        {
            var updatePost = _postUpdater.UpdatePost(postId, postDto);
            return Ok(updatePost);
        }
    }
}
