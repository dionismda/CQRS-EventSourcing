namespace SocialMidia.Write.Application.Interfaces;

public interface ICommandDispatcher
{
    Task Handle<TCommand>(TCommand command)
        where TCommand : BaseCommand;
}