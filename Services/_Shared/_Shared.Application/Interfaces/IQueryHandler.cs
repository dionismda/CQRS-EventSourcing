﻿namespace _Shared.Application.Interfaces;

public interface IQueryHandler<in TQuery, TQueryResult>
    where TQuery : BaseQuery
{
    Task<TQueryResult> Handle(TQuery query);
}
