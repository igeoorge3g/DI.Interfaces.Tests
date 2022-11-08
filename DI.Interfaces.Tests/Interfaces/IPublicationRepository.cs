using DI.Interfaces.Tests.Models;

namespace DI.Interfaces.Tests.Interfaces
{
    public interface IPublicationRepository : IRepository<int, Publication>
    {

        Task<Publication> FindByIdentifier(string identifier);
    }
}
