namespace DI.Interfaces.Tests.Interfaces
{
    public interface IBaseManager<TId, TEntity, TEntityRequest>
    {
        Task<TEntity> Find(TId id);
        Task<TEntity> Insert(TEntityRequest request);
        Task Update(TEntity entity, TEntityRequest request);
    }
}
