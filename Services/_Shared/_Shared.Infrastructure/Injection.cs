namespace _Shared.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectSharedInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IEventModel, EventModel>();

        return services;
    }
}
