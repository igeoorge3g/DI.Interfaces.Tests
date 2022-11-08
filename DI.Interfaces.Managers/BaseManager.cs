using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Shared;

namespace DI.Interfaces.Core.Manager
{
    public abstract class BaseManager<TId, TEntity, TEntityRequest, TEntityResponse> : IBaseManager<TId, TEntity, TEntityRequest, TEntityResponse>
        where TEntity : new()
        where TEntityRequest : new()
        where TEntityResponse : new()
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

        public virtual async Task<TEntityResponse> Insert(TEntityRequest request, bool saveChanges = false)
        {
            var entity = await ToEntity(request);
            await _repository.InsertAsync(entity, saveChanges);
            return await ToResponse(entity);
        }

        public virtual async Task<TEntityResponse> Update(TEntity entity, TEntityRequest request, bool saveChanges = false)
        {
            await _repository.Update(entity, request, saveChanges);
            return await ToResponse(entity);
        }


        public virtual Task<TEntity> ToEntity(TEntityRequest request) => Task.Run(() => { return new TEntity().MapProperties(request); });
        public virtual Task<TEntityRequest> ToRequest(TEntity entity) => Task.Run(() => { return new TEntityRequest().MapProperties(entity); });
        public virtual Task<TEntityResponse> ToResponse(TEntity entity) => Task.Run(() => { return new TEntityResponse().MapProperties(entity); });

    }
}
