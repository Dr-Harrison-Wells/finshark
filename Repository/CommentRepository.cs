using System;
using finshark.Data;
using finshark.Interfaces;
using finshark.Models;
using Microsoft.EntityFrameworkCore;

namespace finshark.Repository;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDBContext _contetxt;
    public CommentRepository(ApplicationDBContext context)
    {   
        _contetxt = context;
    }
    public async Task<List<Comment>> GetAllAsync()
    {
        return await _contetxt.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _contetxt.Comments.FindAsync(id);
    }
}
