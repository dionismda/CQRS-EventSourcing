namespace _Shared.Application.Interfaces;

public interface ICommandHandler<in TCommand>
    where TCommand : BaseCommand
{
    Task Handle(TCommand command, CancellationToken cancellation);
}
