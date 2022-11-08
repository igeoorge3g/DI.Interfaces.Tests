using DI.Interfaces.Core.Models;

namespace DI.Interfaces.Core.Interfaces
{
    public interface IPublicationRepository : IRepository<int, Publication>
    {

        Task<Publication> FindByIdentifier(string identifier);
    }
}
