using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Infrastructure.Persistence;
using DI.Interfaces.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DI.Interfaces.Core.Repositories
{
    public class SalesChannelRepository : AbstractRepository<int, SalesChannel>, ISalesChannelRepository
    {
        public SalesChannelRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<SalesChannel> FindBySellerId(string sellerId)
        {
            return await _context.SalesChannels.FirstOrDefaultAsync(e => e.SellerId == sellerId);
        }
    }
}
