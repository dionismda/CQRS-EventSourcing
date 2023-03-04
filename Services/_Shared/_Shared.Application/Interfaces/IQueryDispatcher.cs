namespace _Shared.Application.Interfaces;

public interface IQueryDispatcher
{
    Task<TResultQuery> Handle<TQuery, TResultQuery>(TQuery query)
        where TQuery : BaseQuery;
}