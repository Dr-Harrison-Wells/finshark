using System;
using finshark.Dtos.Comment;
using finshark.Models;

namespace finshark.Mappers;

public static class CommentMapper
{
    public static CommentDto ToCommentDto(this Comment commentMode)
    {
        return new CommentDto
        {
            Id = commentMode.Id,
            Title = commentMode.Title,
            Content = commentMode.Content,
            CreatedOn = commentMode.CreatedOn,
            StockId = commentMode.StockId
        };
    }
    public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId
        };
    }

}
