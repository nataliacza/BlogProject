using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogProject.Dtos.Posts;
using BlogProject.Services.Interfaces.Posts;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace BlogProject.Web.Controllers;


[Authorize]
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

        if (!allPosts.Any())
        {
            return NoContent();
        }

        return Ok(allPosts);
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetPostDetail([FromRoute] int? postId)
    {
        var postDetail = await _postGetter.GetSinglePost(postId);

        if (postId == 666)
        {
            return StatusCode(418, "OMG! I'm a teapot!");
        }

        if (postDetail == null)
        {
            return NoContent();
        }

        return Ok(postDetail);
        
    }

    [HttpDelete("{postId}")]
    public async Task<IActionResult> RemovePost([FromRoute] int? postId)
    {
        var removePost = await _postRemover.RemovePost(postId);

        if (removePost == null)
        {
            return NotFound($"Post ID {postId} not found!");
        }

        return Ok(removePost);
    }

    [HttpPost]
    public async Task<IActionResult> AddPost([FromBody] AddPostDto addPostDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var addedPost = await _postAdder.AddPost(addPostDto);

        return Created($"api/posts/{addedPost.Id}", addedPost);
    }

    [HttpPut("{postId}")]
    public async Task<IActionResult> UpdatePost([FromRoute] int? postId, [FromBody] UpdatePostDto updatePostDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!postId.HasValue) 
        { 
            return BadRequest(ModelState); 
        }

        var updatedPost = await _postUpdater.UpdatePost(postId, updatePostDto);

        return Ok(updatedPost);
    }
}
