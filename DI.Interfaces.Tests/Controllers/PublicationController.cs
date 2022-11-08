using DI.Interfaces.Tests.Manager;
using DI.Interfaces.Tests.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DI.Interfaces.Tests.Controllers
{
    public class PublicationController : Controller
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
        public async Task<JsonResult> Get(int id)
        {
            var publication = await _publicationManager.Find(id);
            return Json(publication);
        }

        [HttpPost]
        public async Task<JsonResult> Post(PublicationRequest request)
        {
            var publication = await _publicationManager.Insert(request);
            return Json(publication);
        }

        [HttpPut]
        public async Task<JsonResult> Put(int id, PublicationRequest request)
        {
            var publication = await _publicationManager.Find(id);

            await _publicationManager.Update(publication, request);

            return Json(publication);
        }

        [HttpGet]
        public async Task<JsonResult> Sync_Single(int salesChannelId, string identifier)
        {
            var salesChannel = await _salesChannelManager.Find(salesChannelId);
            var publicationResponse = await _integrationManager.Publication_GetByIdentifier(salesChannel, identifier);

            if (publicationResponse is null)
            {
                return Json(new { Success = false, Message = $"{identifier} Not Found" });
            }

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

            return Json(publication);
        }

        [HttpGet]
        public async Task<JsonResult> Sync_Single(int publicationId)
        {
            var publication = await _publicationManager.Find(publicationId);
            var salesChannel = await _salesChannelManager.Find(publication.SalesChannelId);

            var publicationResponse = await _integrationManager.Publication_GetByIdentifier(salesChannel, publication.Identifier);
            var publicationRequest = await _integrationManager.ToPublicationRequest(salesChannel, publicationResponse!);

            await _publicationManager.Update(publication, publicationRequest);

            return Json(publication);
        }
    }
}
