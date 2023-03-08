namespace _Shared.Domain.Core.Write.Exceptions;

public class AggregateNotFoundException : Exception
{
    public AggregateNotFoundException(string message) : base(message)
    {

    }
}
