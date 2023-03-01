namespace _Shared.Domain.Events;

public abstract class BaseEvent : Message
{
    public int Version { get; private set; }
    public string Type { get; private set; }

    protected BaseEvent(string type)
    {
        Type = type;
    }
}
