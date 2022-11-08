#nullable disable
using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Core.Manager;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DI.Interfaces.Core.Controllers
{
    public class PublicationController : BaseController<int, Publication, PublicationFilter, PublicationRequest, PublicationResponse>
    {
        private readonly IntegrationManager _integrationManager;

        public PublicationController(
            IPublicationManager publicationManager,
            IntegrationManager integrationManager) : base(publicationManager)
        {
            _integrationManager = integrationManager;
        }


        [HttpGet, Route("{publicationId}/Sync")]
        public async Task<PublicationResponse> Sync(int publicationId)
        {
            return await _integrationManager.Sync(publicationId);
        }

        [HttpGet, Route("Sync/{salesChannelId}/{identifier}")]

        public async Task<PublicationResponse> Sync(int salesChannelId, string identifier)
        {
            return await _integrationManager.Sync(salesChannelId, identifier);
        }


    }
}
