namespace SocialMidia.Write.Domain.Interfaces;

public interface IEventSourcingHandler<TAggregateRoot>
{
    Task SaveAsync(TAggregateRoot aggregate);
    Task<TAggregateRoot> GetByIdAsync(Guid aggregateId);
    Task RepublishEventsAsync();
}
