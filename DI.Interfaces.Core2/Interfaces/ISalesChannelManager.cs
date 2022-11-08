using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Interfaces
{
    public interface ISalesChannelManager : IBaseManager<int, SalesChannel, SalesChannelRequest, SalesChannelResponse>
    {
    }
}
