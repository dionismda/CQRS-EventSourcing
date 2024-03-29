﻿namespace SocialMidia.Read.Application.Interfaces;

public interface IQueryHandler<in TQuery, TQueryResult>
    where TQuery : BaseQuery
{
    Task<TQueryResult> HandleAsync(TQuery query);
}
