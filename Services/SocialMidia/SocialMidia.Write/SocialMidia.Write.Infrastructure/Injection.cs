namespace SocialMidia.Write.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectSocialMidiaWriteInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEventModel, EventModel>();
        services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        services.AddScoped<IEventSourcingHandler<PostAggregate>, PostEventSourcingHandler>();
        services.AddScoped<IEventStore, SocialMidiaEventStore>();
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

        BsonClassMap.RegisterClassMap<BaseEvent>();
        BsonClassMap.RegisterClassMap<PostCreatedEvent>();
        BsonClassMap.RegisterClassMap<MessageUpdatedEvent>();
        BsonClassMap.RegisterClassMap<PostLikedEvent>();
        BsonClassMap.RegisterClassMap<CommentAddedEvent>();
        BsonClassMap.RegisterClassMap<CommentUpdatedEvent>();
        BsonClassMap.RegisterClassMap<CommentRemovedEvent>();
        BsonClassMap.RegisterClassMap<PostRemovedEvent>();

        return services;
    }
}
