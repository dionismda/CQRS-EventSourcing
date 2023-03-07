namespace _Shared.Domain.Produces;

public interface IEventProducer
{
    Task ProduceAsync<T>(string topic, T @event) where T : BaseEvent;
}