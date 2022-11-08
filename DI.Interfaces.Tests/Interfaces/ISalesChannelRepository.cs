using DI.Interfaces.Tests.Models;

namespace DI.Interfaces.Tests.Interfaces
{
    public interface ISalesChannelRepository : IRepository<int, SalesChannel>
    {

        Task<SalesChannel> FindBySellerId(string sellerId);
    }
}
