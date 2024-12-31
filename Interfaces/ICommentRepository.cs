using System;
using finshark.Models;

namespace finshark.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment> CreateAsync(Comment commentModel);
    Task<Comment?> UpdateAsync(int id,Comment comment);
    Task<Comment?> DeleteAsync(int id);
}
