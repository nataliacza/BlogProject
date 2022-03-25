using BlogProject.Dtos.Posts;
using BlogProject.Services.Interfaces.Posts;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectRefactor.Controllers
{
    //[Route("api/posts")]
    public class PostsContoller : ControllerBase
    {
        private readonly IPostGetter _postGetter;
        private readonly IPostAdder _postAdder;
        private readonly IPostUpdater _postUpdater;
        private readonly IPostRemover _postRemover;

        public PostsContoller(IPostGetter postGetter, IPostAdder postAdder, IPostUpdater postUpdater, IPostRemover postRemover)
        {
            _postGetter = postGetter;
            _postAdder = postAdder;
            _postUpdater = postUpdater;
            _postRemover = postRemover;
        }

        //GET POST LIST
        [HttpGet]
        [Route("api/posts")]
        public IActionResult GetPost()
        {
            var posts = _postGetter.GetAllPosts();
            return Ok(posts);
        }

        //GET SINGLE POST
        [HttpGet]
        [Route("api/posts/{id}")]
        public IActionResult GetPostDetail(int postId)
        {
            var postDetail = _postGetter.GetSinglePost(postId);
            return Ok(postDetail);
        }

        //REMOVE A POST
        [HttpDelete]
        [Route("api/posts/{id}")]
        public IActionResult RemovePost(int postId)
        {
            var removePost = _postRemover.RemovePost(postId);
            return Ok(removePost);
        }

        //CREATE NEW POST
        [HttpPost]
        [Route("api/posts")]
        public IActionResult AddPost(PostDto postDto)
        {
            var addPost = _postAdder.AddPost(postDto);
            return Ok(addPost);
        }

        //UPDATE A POST
        [HttpPut]
        [Route("api/posts/{id}")]
        public IActionResult UpdatePost(int postId, PostDto postDto)
        {
            var updatePost = _postUpdater.UpdatePost(postId, postDto);
            return Ok(updatePost);
        }
    }
}
