#nullable disable
using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.Repositories;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Manager
{
    public class PublicationManager : BaseManager<int, Publication, PublicationRequest, PublicationResponse>, IPublicationManager
    {
        new protected PublicationRepository _repository;

        public PublicationManager(IPublicationRepository repository) : base(repository)
        {

        }

        public override Task<Publication> Find(int id)
        {
            return base.Find(id);
        }

        public async Task<Publication> FindByIdentifier(int salesChannelId, string identifier)
        {
            return await _repository.FindByIdentifier(identifier);
        }


    }
}