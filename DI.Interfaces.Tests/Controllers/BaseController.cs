using DI.Interfaces.Tests.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DI.Interfaces.Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TId, TEntity, TEntityRequest> : ControllerBase
    {
        protected IBaseManager<TId, TEntity, TEntityRequest> _manager;

        public BaseController(IBaseManager<TId, TEntity, TEntityRequest> manager)
        {
            _manager = manager;
        }

        [HttpGet, Route("{id}")]
        public virtual async Task<TEntity> Get(TId id)
        {
            return await _manager.Find(id);
        }

        [HttpPost]
        public virtual async Task<TEntity> Post(TEntityRequest request)
        {
            return await _manager.Insert(request);
        }

        [HttpPut, Route("{id}")]
        public virtual async Task<TEntity> Put(TId id, [FromBody] TEntityRequest request)
        {
            var entity = await _manager.Find(id);
            if (entity is null)
            {
                entity = await _manager.Insert(request);
            }
            else
            {
                await _manager.Update(entity, request);
            }

            return entity;
        }




    }
}
