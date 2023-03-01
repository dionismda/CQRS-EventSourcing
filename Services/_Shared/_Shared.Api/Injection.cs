namespace _Shared.Api;

public static class Injection
{
    public static IServiceCollection InjectShared(this IServiceCollection services)
    {

        return services
                    .InjectSharedApplication()
                    .InjectSharedDomain()
                    .InjectSharedInfrastructure();
    }
}
