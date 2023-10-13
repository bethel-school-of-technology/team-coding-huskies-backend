using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rest_husky.Models;
using rest_husky.Repositories;

namespace rest_husky.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ILogger<CommentController> _logger;
    private readonly ICommentRepository _commentRepo;

    public CommentController(ILogger<CommentController> logger, ICommentRepository commentRepository)
    {
        _logger = logger;
        _commentRepo = commentRepository;
    }

    [HttpGet("{id}")]
    public ActionResult<Comment> GetComment(int id)
    {
        var comment = _commentRepo.GetComment(id);

        if (comment is not null)
        {
            return comment;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost("{postId}/{profileId}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult CreateComment(int postId, int profileId, Comment newComment)
    {
        var profile = _commentRepo.GetProfile(profileId);
        var buzz = _commentRepo.GetBuzz(postId);

        if (!ModelState.IsValid || newComment == null)
        {
            return BadRequest();
        }

        var comment = _commentRepo.CreateComment(profile, buzz, newComment );
        
        return Created(nameof(GetComment), newComment);
    }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult DeleteComment(int id)
    {
        var comment = _commentRepo.GetComment(id);

        if(comment is not null)
        {
            _commentRepo.DeleteComment(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<Buzz> EditComment(Comment comment)
    {

        if (!ModelState.IsValid || comment == null)
        {
            return BadRequest();
        }

        return Ok(_commentRepo.EditComment(comment));
    }
}