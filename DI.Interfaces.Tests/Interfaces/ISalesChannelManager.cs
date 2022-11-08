using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.ViewModels;

namespace DI.Interfaces.Tests.Interfaces
{
    public interface ISalesChannelManager : IBaseManager<int, SalesChannel, SalesChannelRequest>
    {
    }
}
