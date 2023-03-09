namespace SocialMidia.Write.Domain.Interfaces;

public interface IEventProducer
{
    Task ProduceAsync<TEvent>(string topic, TEvent @event) where TEvent : BaseEvent;
}