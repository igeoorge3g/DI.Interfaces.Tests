namespace DI.Interfaces.Tests.Interfaces
{
    public interface IBaseManager<TId, TEntity, TEntityRequest, TEntityResponse>
    {
        Task<TEntity> Find(TId id);
        Task<TEntityResponse> Get(TId id);
        Task<TEntity> Insert(TEntityRequest request);
        Task<TEntityResponse> Update(TEntity entity, TEntityRequest request);

        Task<TEntityResponse> ToResponse(TEntity entity);
        Task<TEntityRequest> ToRequest(TEntity entity);
        Task<TEntity> ToEntity(TEntityRequest request);
    }
}
