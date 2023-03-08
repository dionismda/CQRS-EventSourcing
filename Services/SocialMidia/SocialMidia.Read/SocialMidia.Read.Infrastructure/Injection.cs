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

        services.RegisterEventHandler<PostEventHandler, PostCreatedEvent>();
        services.RegisterEventHandler<PostEventHandler, MessageUpdatedEvent>();
        services.RegisterEventHandler<PostEventHandler, PostLikedEvent>();
        services.RegisterEventHandler<PostEventHandler, PostRemovedEvent>();

        services.RegisterEventHandler<CommentEventHandler, CommentAddedEvent>();
        services.RegisterEventHandler<CommentEventHandler, CommentUpdatedEvent>();
        services.RegisterEventHandler<CommentEventHandler, CommentRemovedEvent>();

        return services;
    }
}