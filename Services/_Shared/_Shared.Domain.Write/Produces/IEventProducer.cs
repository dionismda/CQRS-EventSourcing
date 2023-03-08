namespace _Shared.Domain.Core.Write.Produces;

public interface IEventProducer
{
    Task ProduceAsync<T>(string topic, T @event) where T : BaseEvent;
}