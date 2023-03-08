namespace SocialMidia.Read.Infrastructure.Extensions;

public static class EventHandlerRegistration
{
    public static IServiceCollection RegisterEventHandler<TEventHandler, TEvent>(this IServiceCollection services)
        where TEvent : BaseEvent
        where TEventHandler : class, IEventHandler<TEvent>
    {
        return services.AddScoped<IEventHandler<TEvent>, TEventHandler>();
    }
}
