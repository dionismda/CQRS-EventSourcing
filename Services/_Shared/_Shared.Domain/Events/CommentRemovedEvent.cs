namespace _Shared.Domain.Events;

public class CommentRemovedEvent : BaseEvent
{
    public CommentRemovedEvent() : base(nameof(CommentRemovedEvent))
    {
    }

    public Guid CommentId { get; set; }
}
