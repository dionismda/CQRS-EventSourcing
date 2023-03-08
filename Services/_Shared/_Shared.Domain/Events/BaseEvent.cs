using _Shared.Domain.Core.Messages;

namespace _Shared.Domain.Core.Events;

public abstract class BaseEvent : Message
{
    public int Version { get; set; }
    public string Type { get; set; }

    protected BaseEvent(string type)
    {
        Type = type;
    }
}
