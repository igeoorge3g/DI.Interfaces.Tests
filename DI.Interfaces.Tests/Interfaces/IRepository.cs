namespace DI.Interfaces.Tests.Interfaces
{
    public interface IRepository<TId, TEntity>
    {

        Task<TEntity> GetAsync(TId id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task Update(TEntity entity);
    }
}
