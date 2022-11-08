using DI.Interfaces.Tests.Interfaces;

namespace DI.Interfaces.Tests.Manager
{
    public abstract class BaseManager<TId, TEntity, TEntityRequest> : IBaseManager<TId, TEntity, TEntityRequest>
    {
        protected readonly IRepository<TId, TEntity> _repository;
        public BaseManager(IRepository<TId, TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> Find(TId id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task<TEntity> Insert(TEntityRequest request)
        {
            var entity = await ToEntity(request);
            return await _repository.InsertAsync(entity);
        }

        public virtual async Task Update(TEntity entity, TEntityRequest request)
        {
            await _repository.Update(entity);
        }

        protected abstract Task<TEntity> ToEntity(TEntityRequest request);
        protected abstract Task<TEntityRequest> ToRequest(TEntity entity);

    }
}
