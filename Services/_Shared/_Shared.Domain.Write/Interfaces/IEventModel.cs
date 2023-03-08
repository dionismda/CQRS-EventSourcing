namespace _Shared.Domain.Core.Write.Interfaces;

public interface IEventModel
{
    string Id { get; }
    DateTime TimeStamp { get; }
    Guid AggregateIdentifier { get; }
    string AggregateType { get; }
    int Version { get; }
    string EventType { get; }
    BaseEvent EventData { get; }
}
