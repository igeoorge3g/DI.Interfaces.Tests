using DI.Interfaces.Tests.Interfaces;
using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.ViewModels;

namespace DI.Interfaces.Tests.Controllers
{
    public class SalesChannelController : BaseController<int, SalesChannel, SalesChannelRequest>
    {
        public SalesChannelController(ISalesChannelManager manager) : base(manager)
        {
        }
    }
}
