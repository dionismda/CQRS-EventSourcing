namespace _Shared.Application.Interfaces;

public interface ICommandDispatcher
{
    Task Handle<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : BaseCommand;
}