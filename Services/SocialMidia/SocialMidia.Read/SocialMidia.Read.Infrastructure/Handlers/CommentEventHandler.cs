namespace SocialMidia.Read.Infrastructure.Handlers;

public class CommentEventHandler : IEventHandler<CommentAddedEvent>, 
IEventHandler<CommentUpdatedEvent>, IEventHandler<CommentRemovedEvent>
{
    private readonly ICommentRepository _commentRepository;

    public CommentEventHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task HandleAsync(CommentAddedEvent @event)
    {
        var comment = new CommentEntity
        {
            PostId = @event.Id,
            Id = @event.CommentId,
            CommentDate = @event.CommentDate,
            Comment = @event.Comment,
            Username = @event.Username,
            Edited = false
        };

        await _commentRepository.CreateAsync(comment);
    }

    public async Task HandleAsync(CommentUpdatedEvent @event)
    {
        var comment = await _commentRepository.GetByIdAsync(@event.CommentId);

        if (comment == null) return;

        comment.Comment = @event.Comment;
        comment.Edited = true;
        comment.CommentDate = @event.EditDate;

        await _commentRepository.UpdateAsync(comment);
    }

    public async Task HandleAsync(CommentRemovedEvent @event)
    {
        await _commentRepository.DeleteAsync(@event.CommentId);
    }
}
