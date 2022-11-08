using DI.Interfaces.Core.Models;

namespace DI.Interfaces.Core.Interfaces
{
    public interface ISalesChannelRepository : IRepository<int, SalesChannel>
    {
        Task<SalesChannel> FindBySellerId(string sellerId);
    }
}
