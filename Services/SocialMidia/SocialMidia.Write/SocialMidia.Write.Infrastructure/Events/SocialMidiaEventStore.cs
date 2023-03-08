namespace SocialMidia.Write.Infrastructure.Events;

public class SocialMidiaEventStore : EventStore
{
    public SocialMidiaEventStore(IEventStoreRepository eventStoreRepository, IEventProducer eventProducer) : base(eventStoreRepository, eventProducer)
    {
    }

    public override async Task SaveEventsAsync(Guid aggregateId, IEnumerable<BaseEvent> events, int expectedVersion)
    {
        var eventStream = await EventStoreRepository.FindByAggregateId(aggregateId);

        if (expectedVersion != -1 && eventStream[^1].Version != expectedVersion)
            throw new ConcurrencyException();

        var version = expectedVersion;

        foreach (var @event in events)
        {
            version++;
            @event.Version = version;
            var eventType = @event.GetType().Name;
            var eventModel = new EventModel
            {
                TimeStamp = DateTime.Now,
                AggregateIdentifier = aggregateId,
                AggregateType = nameof(PostAggregate),
                Version = version,
                EventType = eventType,
                EventData = @event
            };

            await EventStoreRepository.SaveAsync(eventModel);

            var topic = Environment.GetEnvironmentVariable("KAFKA_TOPIC");
            await EventProducer.ProduceAsync(topic, @event);
        }
    }
}
