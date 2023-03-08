namespace _Shared.Domain.Core.Write.Interfaces;

public interface IEventStoreRepository
{
    Task SaveAsync(IEventModel @event);
    Task<List<IEventModel>> FindByAggregateId(Guid aggregateId);
    Task<List<IEventModel>> FindAllAsync();
}