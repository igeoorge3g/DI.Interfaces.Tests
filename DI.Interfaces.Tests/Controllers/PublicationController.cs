using DI.Interfaces.Tests.Manager;
using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DI.Interfaces.Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicationController : ControllerBase
    {
        private readonly IntegrationManager _integrationManager;
        private readonly PublicationManager _publicationManager;
        private readonly SalesChannelManager _salesChannelManager;

        public PublicationController(
            IntegrationManager integrationManager,
            PublicationManager publicationManager,
            SalesChannelManager salesChannelManager)
        {
            _integrationManager = integrationManager;
            _publicationManager = publicationManager;
            _salesChannelManager = salesChannelManager;
        }

        [HttpGet]
        public async Task<Publication> Get(int id)
        {
            var publication = await _publicationManager.Find(id);
            return publication;
        }

        [HttpPost]
        public async Task<Publication> Post(PublicationRequest request)
        {
            var publication = await _publicationManager.Insert(request);
            return publication;
        }

        [HttpPut, Route("{id}")]
        public async Task<Publication> Put(int id, [FromBody] PublicationRequest request)
        {
            var publication = await _publicationManager.Find(id);

            await _publicationManager.Update(publication, request);

            return publication;
        }

        [HttpGet, Route("{publicationId}/Sync")]
        public async Task<Publication> Sync(int publicationId)
        {
            var publication = await _publicationManager.Find(publicationId);
            var salesChannel = await _salesChannelManager.Find(publication.SalesChannelId);

            var publicationResponse = await _integrationManager.Publication_GetByIdentifier(salesChannel, publication.Identifier);
            var publicationRequest = await _integrationManager.ToPublicationRequest(salesChannel, publicationResponse!);

            await _publicationManager.Update(publication, publicationRequest);

            return publication;
        }

        [HttpGet, Route("Sync/{salesChannelId}/{identifier}")]

        public async Task<Publication> Sync(int salesChannelId, string identifier)
        {
            var salesChannel = await _salesChannelManager.Find(salesChannelId);
            var publicationResponse = await _integrationManager.Publication_GetByIdentifier(salesChannel, identifier);

            //if (publicationResponse is null)
            //{
            //    return NotFound(new { Success = false, Message = $"{identifier} Not Found" });
            //}

            PublicationRequest publicationRequest = await _integrationManager.ToPublicationRequest(salesChannel, publicationResponse!);

            var publication = await _publicationManager.FindByIdentifier(identifier);
            if (publication is null)
            {
                publication = await _publicationManager.Insert(publicationRequest);
            }
            else
            {
                await _publicationManager.Update(publication, publicationRequest);
            }

            return publication;
        }

        
    }
}
