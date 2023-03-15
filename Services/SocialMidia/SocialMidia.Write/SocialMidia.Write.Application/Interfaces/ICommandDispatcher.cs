namespace SocialMidia.Write.Application.Interfaces;

public interface ICommandDispatcher
{
    Task HandleAsync<TCommand>(TCommand command)
        where TCommand : BaseCommand;
}