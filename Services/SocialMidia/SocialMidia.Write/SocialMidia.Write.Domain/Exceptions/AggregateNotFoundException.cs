namespace SocialMidia.Write.Domain.Exceptions;

public class AggregateNotFoundException : Exception
{
    public AggregateNotFoundException(string message) : base(message)
    {

    }
}
