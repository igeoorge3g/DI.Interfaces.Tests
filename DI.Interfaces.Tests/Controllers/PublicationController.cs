using DI.Interfaces.Tests.Interfaces;
using DI.Interfaces.Tests.Manager;
using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DI.Interfaces.Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicationController : BaseController<int, Publication, PublicationRequest>
    {
        private new readonly PublicationManager _manager;
        private readonly IntegrationManager _integrationManager;
        private readonly ISalesChannelManager _salesChannelManager;

        public PublicationController(
            IntegrationManager integrationManager,
            IPublicationManager publicationManager,
            ISalesChannelManager salesChannelManager) : base(publicationManager)
        {
            _integrationManager = integrationManager;
            _salesChannelManager = salesChannelManager;
        }



        [HttpGet, Route("{publicationId}/Sync")]
        public async Task<Publication> Sync(int publicationId)
        {
            var publication = await _manager.Find(publicationId);
            var salesChannel = await _salesChannelManager.Find(publication.SalesChannelId);

            var publicationResponse = await _integrationManager.Publication_GetByIdentifier(salesChannel, publication.Identifier);
            var publicationRequest = await _integrationManager.ToPublicationRequest(salesChannel, publicationResponse!);

            await _manager.Update(publication, publicationRequest);

            return publication;
        }

        [HttpGet, Route("Sync/{salesChannelId}/{identifier}")]

        public async Task<Publication> Sync(int salesChannelId, string identifier)
        {
            var salesChannel = await _salesChannelManager.Find(salesChannelId);
            var publicationResponse = await _integrationManager.Publication_GetByIdentifier(salesChannel, identifier);

            PublicationRequest publicationRequest = await _integrationManager.ToPublicationRequest(salesChannel, publicationResponse!);

            var publication = await _manager.FindByIdentifier(identifier);
            if (publication is null)
            {
                publication = await _manager.Insert(publicationRequest);
            }
            else
            {
                await _manager.Update(publication, publicationRequest);
            }

            return publication;
        }


    }
}
