﻿namespace SocialMidia.Read.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly DatabaseContext _context;

    public CommentRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CommentEntity> GetByIdAsync(Guid commentId)
    {
        return await _context.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
    }

    public async Task UpdateAsync(CommentEntity comment)
    {
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid commentId)
    {
        var comment = await GetByIdAsync(commentId);

        if (comment == null) return;

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }

    public async Task CreateAsync(CommentEntity comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }
}