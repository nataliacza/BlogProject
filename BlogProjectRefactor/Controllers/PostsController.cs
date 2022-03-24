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
        public IActionResult GetPosts()
        {
            var posts = _postGetter.GetPosts();
            return Ok(posts);
        }

        //GET SINGLE POST
        [HttpGet]
        [Route("api/posts/{id}")]
        public IActionResult GetPostDetail(int id)
        {
            var postDetail = _postGetter.GetSinglePost(id);
            return Ok(postDetail);
        }

        //CREATE NEW POST
        [HttpPost]
        [Route("api/posts/create")]
        public IActionResult CreatePost()
        {
            var posts = _postAdder.AddPost();
            return Ok(posts);
        }

        //REMOVE A POST
        [HttpDelete]
        [Route("api/posts/{id}")]
        public IActionResult RemovePost(int id)
        {
            var removePost = _postRemover.RemovePost(id);
            return Ok(removePost);
        }

        //UPDATE A POST
        //[HttpPut]
        //[Route("api/posts/{id}")]
        //public IActionResult UpdatePost(int id)
        //{
        //    var updatePost = _postUpdater.UpdatePost(id);
        //    return Ok(updatePost);
        //}

    }
}
