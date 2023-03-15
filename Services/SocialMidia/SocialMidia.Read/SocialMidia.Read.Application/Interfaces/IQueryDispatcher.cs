namespace SocialMidia.Read.Application.Interfaces;

public interface IQueryDispatcher
{
    Task<TResultQuery> HandleAsync<TQuery, TResultQuery>(TQuery query)
        where TQuery : BaseQuery;
}