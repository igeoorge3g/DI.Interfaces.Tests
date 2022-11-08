using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Infrastructure.Persistence;

namespace DI.Interfaces.Infrastructure.Repositories
{
    public abstract class AbstractRepository<TId, TEntity> : IRepository<TId, TEntity>
        where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        public AbstractRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> InsertAsync(TEntity entity, bool saveChanges = false)
        {
            entity = _context.Set<TEntity>().Add(entity).Entity;
            await SaveChanges(saveChanges);
            return entity;
        }

        public async Task Update<TRequest>(TEntity entity, TRequest request, bool saveChanges = false)
        {
            _context.Set<TEntity>().Entry(entity).CurrentValues.SetValues(request);
            await SaveChanges(saveChanges);
        }

        public async Task<int> SaveChanges(bool saveChanges = true)
        {
            if (!saveChanges)
            {
                return 0;
            }

            return await _context.SaveChangesAsync();
        }
    }
}
