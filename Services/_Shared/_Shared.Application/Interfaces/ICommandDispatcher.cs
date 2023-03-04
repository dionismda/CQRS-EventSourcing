namespace _Shared.Application.Interfaces;

public interface ICommandDispatcher
{
    Task Handle<TCommand>(TCommand command)
        where TCommand : BaseCommand;
}