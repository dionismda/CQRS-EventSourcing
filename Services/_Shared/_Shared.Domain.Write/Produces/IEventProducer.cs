namespace _Shared.Domain.Core.Write.Produces;

public interface IEventProducer
{
    Task ProduceAsync<TEvent>(string topic, TEvent @event) where TEvent : BaseEvent;
}