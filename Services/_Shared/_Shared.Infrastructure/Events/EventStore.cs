namespace _Shared.Infrastructure.Write.Events;

public abstract class EventStore : IEventStore
{
    protected readonly IEventStoreRepository EventStoreRepository;
    protected readonly IEventProducer EventProducer;

    public EventStore(IEventStoreRepository eventStoreRepository, IEventProducer eventProducer)
    {
        EventStoreRepository = eventStoreRepository;
        EventProducer = eventProducer;
    }

    public async Task<List<Guid>> GetAggregateIdsAsync()
    {
        var eventStream = await EventStoreRepository.FindAllAsync();

        if (eventStream == null || !eventStream.Any())
            throw new ArgumentNullException(nameof(eventStream), "Could not retrieve event stream from the event store!");

        return eventStream.Select(x => x.AggregateIdentifier).Distinct().ToList();
    }

    public async Task<List<BaseEvent>> GetEventsAsync(Guid aggregateId)
    {
        var eventStream = await EventStoreRepository.FindByAggregateId(aggregateId);

        if (eventStream == null || !eventStream.Any())
            throw new AggregateNotFoundException("Incorrect post ID provided!");

        return eventStream.OrderBy(x => x.Version).Select(x => x.EventData).ToList();
    }

    public abstract Task SaveEventsAsync(Guid aggregateId, IEnumerable<BaseEvent> events, int expectedVersion);
    
}
