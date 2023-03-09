namespace SocialMidia.Read.Domain.Consumers;

public interface IEventConsumer
{
    void Consume(string topic);
}
