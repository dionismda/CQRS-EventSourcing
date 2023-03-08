namespace SocialMidia.Read.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectSocialMidiaReadInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("PostgresServer"));
        });

        var dataContext = services.BuildServiceProvider().GetRequiredService<DatabaseContext>();
        dataContext.Database.EnsureCreated();

        return services;
    }
}