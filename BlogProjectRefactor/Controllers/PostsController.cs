using BlogProject.Services.Interfaces.Posts;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjectRefactor.Controllers
{
    //[Route("api/posts")]
    public class PostsContoller : ControllerBase
    {
        private readonly IPostGetter _postGetter;

        public PostsContoller(IPostGetter postGetter)
        {
            _postGetter = postGetter;
        }

        //GET POST LIST
        [HttpGet]
        [Route("api/posts")]
        public IActionResult GetPosts()
        {
            var posts = _postGetter.Get();
            return Ok(posts);
        }

        //GET POST DETAIL
        [HttpGet]
        [Route("api/posts/{id}")]
        public IActionResult GetPostDetail(int id)
        {
            var postDetail = _postGetter.Get(id);
            return Ok(postDetail);
        }

        //CREATE NEW POST
        //[HttpGet]
        //[Route("api/posts/create")]
        //public IActionResult CreatePost()
        //{
        //    var posts = _postGetter.Add();
        //    return Ok(posts);
        //}

        //DELETE POST
        //[HttpGet]
        //[Route("api/posts")]
        //public IActionResult DeletePost()
        //{
        //    var posts = _postGetter.Delete();
        //    return Ok(posts);
        //}
    }
}
