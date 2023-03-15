namespace SocialMidia.Read.Application.Dispatchers;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResultQuery> HandleAsync<TQuery, TResultQuery>(TQuery query)
        where TQuery : BaseQuery
    {
        if (_serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResultQuery>)) is not IQueryHandler<TQuery, TResultQuery> service)
            throw new InvalidCastException("Could not find injection QueryHandler");

        return await service.HandleAsync((dynamic)query);
    }
}
