namespace SocialMidia.Read.Domain.Interfaces;

public interface ICommentRepository
{
    Task CreateAsync(CommentEntity comment);
    Task<CommentEntity> GetByIdAsync(Guid commentId);
    Task UpdateAsync(CommentEntity comment);
    Task DeleteAsync(Guid commentId);
}