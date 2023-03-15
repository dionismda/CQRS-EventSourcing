namespace SocialMidia.Read.Application.Extensions;

public static class QueryHandlerRegistration
{
    public static IServiceCollection RegisterQueryHandler<TQueryHandler, TQuery, TQueryResult>(this IServiceCollection services)
        where TQuery : BaseQuery
        where TQueryHandler : class, IQueryHandler<TQuery, TQueryResult>
    {
        return services.AddScoped<IQueryHandler<TQuery, TQueryResult>, TQueryHandler>();
    }
}