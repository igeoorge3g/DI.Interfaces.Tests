namespace DI.Interfaces.Core.Interfaces
{
    public interface IRepository<TId, TEntity>
    {

        Task<TEntity> GetAsync(TId id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task Update(TEntity entity);
    }
}
