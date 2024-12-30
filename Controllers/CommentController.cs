using System;
using finshark.Dtos.Comment;
using finshark.Interfaces;
using finshark.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace finshark.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _commentRepo;
    private readonly IstockRepository _stockReppo;
    public CommentController(ICommentRepository commentRepo, IstockRepository stockRepo)
    {
        _commentRepo = commentRepo;
        _stockReppo = stockRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var comments = await _commentRepo.GetAllAsync();
        var commentDto = comments.Select(s => s.ToCommentDto());
        return Ok(commentDto);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var comment = await _commentRepo.GetByIdAsync(id);

        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment.ToCommentDto());
    }

    [HttpPost("{stockId:int}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto commentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (!await _stockReppo.StockExists(stockId))
            return BadRequest("stock does not exit");

        var commentModel = commentDto.ToCommentFromCreate(stockId);
        await _commentRepo.CreateAsync(commentModel);
        return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var commentModel = await _commentRepo.DeleteAsync(id);
        if (commentModel == null)
        {
            return NotFound("comment does not exit");
        }
        return Ok(commentModel);
    }
}
