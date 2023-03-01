namespace SocialMidia.Write.Domain.Events;

public class PostRemovedEvent : BaseEvent
{
    public PostRemovedEvent() : base(nameof(PostRemovedEvent))
    {
    }
}