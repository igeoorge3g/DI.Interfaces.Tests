using DI.Interfaces.Tests.Interfaces;
using DI.Interfaces.Tests.Models;

namespace DI.Interfaces.Tests.Repositories
{
    public class SalesChannelRepository : ISalesChannelRepository
    {
        public Task<SalesChannel> FindBySellerId(string sellerId)
        {
            throw new NotImplementedException();
        }

        public async Task<SalesChannel> GetAsync(int id)
        {
            //TODO: TESTING CODE
            return await Task.Run(() =>
            {
                return new SalesChannel { Id = id };
            });
        }

        public async Task<SalesChannel> InsertAsync(SalesChannel entity)
        {
            //TODO: TESTING CODE
            return await GetAsync(entity.Id);
        }

        public async Task Update(SalesChannel entity)
        {
            await Task.Run(() =>
            {
                //TODO: TESTING CODE
            });
        }
    }
}
