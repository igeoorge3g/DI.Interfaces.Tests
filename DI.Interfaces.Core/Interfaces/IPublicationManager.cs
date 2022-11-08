using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Interfaces
{
    public interface IPublicationManager : IBaseManager<int, Publication, PublicationRequest, PublicationResponse>
    {
        Task<Publication> FindByIdentifier(int salesChannelId, string identifier);
    }
}
