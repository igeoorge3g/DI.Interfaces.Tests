namespace DI.Interfaces.Core.Interfaces
{
    public interface IRepository<TId, TEntity>
    {
        Task<TEntity> GetAsync(TId id);
        Task<TEntity> InsertAsync(TEntity entity, bool saveChanges = false);
        Task Update<TRequest>(TEntity entity, TRequest request, bool saveChanges = false);
        Task<int> SaveChanges(bool saveChanges = true);
    }
}
