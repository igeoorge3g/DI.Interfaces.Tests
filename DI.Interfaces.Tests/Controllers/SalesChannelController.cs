using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Controllers
{
    public class SalesChannelController : BaseController<int, SalesChannel, SalesChannelFilter, SalesChannelRequest, SalesChannelResponse>
    {
        public SalesChannelController(ISalesChannelManager manager) : base(manager)
        {
        }
    }
}
