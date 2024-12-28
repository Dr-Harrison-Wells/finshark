using System;
using finshark.Dtos.Comment;
using finshark.Interfaces;
using finshark.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace finshark.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController:ControllerBase
{
    private readonly ICommentRepository _commentReppo;
    public CommentController(ICommentRepository commentRepo)
    {
        _commentReppo = commentRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentReppo.GetAllAsync();
        var commentDto = comments.Select(s=>s.ToCommentDto());
        return Ok(commentDto);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _commentReppo.GetByIdAsync(id);

        if(comment==null)
        {
            return NotFound();
        }
        return Ok(comment.ToCommentDto);
    }
}
