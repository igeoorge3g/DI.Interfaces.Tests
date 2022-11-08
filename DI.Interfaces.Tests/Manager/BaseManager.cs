using DI.Interfaces.Tests.Interfaces;

namespace DI.Interfaces.Tests.Manager
{
    public abstract class BaseManager<TId, TEntity, TEntityRequest, TEntityResponse> : IBaseManager<TId, TEntity, TEntityRequest, TEntityResponse>
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

        public virtual async Task<TEntityResponse> Get(TId id)
        {
            var entity = await Find(id);
            return await ToResponse(entity);
        }

        public virtual async Task<TEntity> Insert(TEntityRequest request)
        {
            var entity = await ToEntity(request);
            return await _repository.InsertAsync(entity);
        }

        public virtual async Task<TEntityResponse> Update(TEntity entity, TEntityRequest request)
        {
            await _repository.Update(entity);
            return await ToResponse(entity);
        }

        public abstract Task<TEntity> ToEntity(TEntityRequest request);
        public abstract Task<TEntityRequest> ToRequest(TEntity entity);
        public abstract Task<TEntityResponse> ToResponse(TEntity entity);

    }
}
