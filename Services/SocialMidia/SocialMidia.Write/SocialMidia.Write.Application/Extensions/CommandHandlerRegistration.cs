namespace SocialMidia.Write.Application.Extensions;

public static class CommandHandlerRegistration
{
    public static IServiceCollection RegisterCommandHandler<TCommandHandler, TCommand>(this IServiceCollection services)
        where TCommand : BaseCommand
        where TCommandHandler : class, ICommandHandler<TCommand>
    {
        return services.AddScoped<ICommandHandler<TCommand>, TCommandHandler>();
    }
}