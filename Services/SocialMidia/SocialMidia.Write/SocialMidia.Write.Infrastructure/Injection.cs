namespace SocialMidia.Write.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectSocialMidiaWriteInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {        
        services.AddScoped<IEventModel, EventModel>();
        services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        services.AddScoped<IEventSourcingHandler<PostAggregate>, PostEventSourcingHandler>();
        services.AddScoped<IEventStore, EventStore>();
        services.AddScoped<IEventProducer, EventProducer>();

        var mongoDbconfiguration = configuration.GetSection(nameof(MongoDbConfiguration));
        services.Configure<MongoDbConfiguration>(opt =>
        {
            opt.ConnectionString = mongoDbconfiguration[nameof(MongoDbConfiguration.ConnectionString)];
            opt.Database = mongoDbconfiguration[nameof(MongoDbConfiguration.Database)];
            opt.Collection = mongoDbconfiguration[nameof(MongoDbConfiguration.Collection)];
        });

        var producerConfig = configuration.GetSection(nameof(ProducerConfig));
        services.Configure<ProducerConfig>(opt =>
        {
            opt.BootstrapServers = mongoDbconfiguration[nameof(ProducerConfig.BootstrapServers)];
        });

        return services;
    }
}
