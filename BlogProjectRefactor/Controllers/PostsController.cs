using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogProject.Dtos.Posts;
using BlogProject.Services.Interfaces.Posts;


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
            var allPosts = await _postGetter.GetAllPosts();
            return Ok(allPosts);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostDetail(int postId)
        {
            var postDetail = await _postGetter.GetSinglePost(postId);

            if (postDetail is null)
            {
                return NotFound();
            }
            
            return Ok(postDetail);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> RemovePost(int postId)
        {
            var removedPost = await _postRemover.RemovePost(postId);

            if (removedPost is null)
            {
                return NotFound();
            }

            return Ok(removedPost);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] AddPostDto addPostDto)
        {
            var addPost = await _postAdder.AddPost(addPostDto);
            string resourceCreated = "Resource created!";
            return Created(resourceCreated, addPostDto);
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, [FromBody] UpdatePostDto updatePostDto)
        {
            var updatePost = await _postUpdater.UpdatePost(postId, updatePostDto);
            return Ok(updatePost);
        }
    }
}
