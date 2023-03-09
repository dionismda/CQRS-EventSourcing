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

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IEventConsumer, EventConsumer>();
        services.AddScoped<IEventHandler, SocialMidiaEventHandler>();

        services.AddHostedService<ConsumerHostedService>();

        return services;
    }
}