#nullable disable
using DI.Interfaces.Tests.Interfaces;
using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.Repositories;
using DI.Interfaces.Tests.ViewModels;

namespace DI.Interfaces.Tests.Manager
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

        public override Task<Publication> ToEntity(PublicationRequest request)
        {
            return Task.Run(() =>
            {
                return new Publication { Name = request.Name, Identifier = request.Identifier };
            });
        }

        public override Task<PublicationRequest> ToRequest(Publication entity)
        {
            return Task.Run(() =>
            {
                return new PublicationRequest { Name = entity.Name };
            });
        }

        public override Task<PublicationResponse> ToResponse(Publication entity)
        {
            return Task.Run(() =>
            {
                return new PublicationResponse { };
            });
        }
    }
}