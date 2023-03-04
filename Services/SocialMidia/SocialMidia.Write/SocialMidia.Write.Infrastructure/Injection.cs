namespace SocialMidia.Write.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectSocialMidiaWriteInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEventModel, EventModel>();
        services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        services.AddScoped<IEventSourcingHandler<PostAggregate>, PostEventSourcingHandler>();
        services.AddScoped<IEventStore, EventStore>();

        return services;
    }
}
