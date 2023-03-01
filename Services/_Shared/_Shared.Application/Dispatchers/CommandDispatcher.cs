namespace _Shared.Application.Dispatchers;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle<TCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : BaseCommand
    {
        if (_serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) is not ICommandHandler<TCommand> service)
            throw new InvalidCastException("Could not find injection CommandHandler");

        await service.Handle((dynamic)command, cancellationToken);
    }
}