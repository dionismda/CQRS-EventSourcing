namespace SocialMidia.Read.Infrastructure.Interfaces;

public interface IEventHandler
{
    Task HandleAsync(PostCreatedEvent @event);
    Task HandleAsync(MessageUpdatedEvent @event);
    Task HandleAsync(PostLikedEvent @event);
    Task HandleAsync(CommentAddedEvent @event);
    Task HandleAsync(CommentUpdatedEvent @event);
    Task HandleAsync(CommentRemovedEvent @event);
    Task HandleAsync(PostRemovedEvent @event);
}
