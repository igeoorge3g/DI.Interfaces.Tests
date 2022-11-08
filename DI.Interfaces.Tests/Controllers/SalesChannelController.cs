using DI.Interfaces.Core.Integrations.Interfaces;
using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Core.Manager;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Controllers
{
    public class SalesChannelController : BaseController<int, SalesChannel, SalesChannelFilter, SalesChannelRequest, SalesChannelResponse>
    {
        private readonly IntegrationManager _integrationManager;
        public SalesChannelController(ISalesChannelManager manager, IntegrationManager integrationManager) : base(manager)
        {
            _integrationManager = integrationManager;
        }

        public async Task<IEnumerable<PublicationResponse>> Sync_All(int salesChannelId)
        {
            var responses = await _integrationManager.Sync_All(salesChannelId);
            return responses;
        }
    }
}
