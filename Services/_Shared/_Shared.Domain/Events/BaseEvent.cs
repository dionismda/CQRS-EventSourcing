namespace _Shared.Domain.Events;

public abstract class BaseEvent : Message
{
    public int Version { get; set; }
    public string Type { get; set; }

    protected BaseEvent(string type)
    {
        Type = type;
    }
}
