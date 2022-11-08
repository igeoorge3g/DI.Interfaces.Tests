using DI.Interfaces.Tests.Interfaces;
using DI.Interfaces.Tests.Models;

namespace DI.Interfaces.Tests.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        public Task<Publication> FindByIdentifier(string identifier)
        {
            throw new NotImplementedException();
        }

        public async Task<Publication> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return new Publication { Id = id };
            });
        }

        public async Task<Publication> InsertAsync(Publication entity)
        {
            return await Task.Run(() =>
            {
                return entity;
            });
        }

        public async Task Update(Publication entity)
        {
            await Task.Run(() =>
            {

            });
        }
    }
}
