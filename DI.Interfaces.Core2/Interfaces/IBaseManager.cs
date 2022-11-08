namespace DI.Interfaces.Core.Interfaces
{
    public interface IBaseManager<TId, TEntity, TEntityRequest, TEntityResponse>
    {
        Task<TEntity> Find(TId id);
        Task<TEntityResponse> Get(TId id);
        Task<TEntityResponse> Insert(TEntityRequest request, bool saveChanges = false);
        Task<TEntityResponse> Update(TEntity entity, TEntityRequest request, bool saveChanges = false);

        Task<TEntityResponse> ToResponse(TEntity entity);
        Task<TEntityRequest> ToRequest(TEntity entity);
        Task<TEntity> ToEntity(TEntityRequest request);
    }
}
