using DI.Interfaces.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DI.Interfaces.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TId, TEntity, TEntityFilter, TEntityRequest, TEntityResponse> : ControllerBase
    {
        protected IBaseManager<TId, TEntity, TEntityRequest, TEntityResponse> _manager;

        public BaseController(IBaseManager<TId, TEntity, TEntityRequest, TEntityResponse> manager)
        {
            _manager = manager;
        }

        [HttpGet, Route("{id}")]
        public virtual async Task<TEntityResponse> Get(TId id)
        {
            var entity = await _manager.Find(id);
            return await _manager.ToResponse(entity);
        }

        [HttpPost]
        public virtual async Task<TEntityResponse> Post(TEntityRequest request)
        {
            return await _manager.Insert(request, true);
        }

        [HttpPut, Route("{id}")]
        public virtual async Task<TEntityResponse> Put(TId id, [FromBody] TEntityRequest request)
        {
            var entity = await _manager.Find(id);
            return await _manager.Update(entity, request, true);
        }
    }
}
