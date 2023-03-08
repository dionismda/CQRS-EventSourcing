namespace _Shared.Infrastructure.Read.Interfaces;

public interface IEventHandler<in TEvent>
    where TEvent : BaseEvent
{
    Task HandleAsync(TEvent @event);
}
