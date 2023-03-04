namespace _Shared.Application.Interfaces;

public interface ICommandHandler<in TCommand>
    where TCommand : BaseCommand
{
    Task HandleAsync(TCommand command);
}
