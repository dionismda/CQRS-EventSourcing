namespace SocialMidia.Read.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectSocialMidiaReadInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("PostgresServer"));
        });

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


        services.AddSingleton(new DatabaseContextFactory(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("PostgresServer"));
        }));

        var consumerConfig = configuration.GetSection(nameof(ConsumerConfig));
        services.Configure<ConsumerConfig>(opt =>
        {
            opt.GroupId = consumerConfig[nameof(ConsumerConfig.GroupId)];
            opt.BootstrapServers = consumerConfig[nameof(ConsumerConfig.BootstrapServers)];
            opt.EnableAutoCommit = Boolean.Parse(consumerConfig[nameof(ConsumerConfig.EnableAutoCommit)]);
            opt.AutoOffsetReset = AutoOffsetReset.Earliest;
            opt.AllowAutoCreateTopics = Boolean.Parse(consumerConfig[nameof(ConsumerConfig.AllowAutoCreateTopics)]);
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