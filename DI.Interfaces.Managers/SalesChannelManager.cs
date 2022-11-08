#nullable disable
using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.Repositories;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Manager
{
    public class SalesChannelManager : BaseManager<int, SalesChannel, SalesChannelRequest, SalesChannelResponse>, ISalesChannelManager
    {
        new protected SalesChannelRepository _repository;
        public SalesChannelManager(ISalesChannelRepository repository) : base(repository)
        {
        }

        public override Task<SalesChannel> ToEntity(SalesChannelRequest request)
        {
            throw new NotImplementedException();
        }

        public override Task<SalesChannelRequest> ToRequest(SalesChannel entity)
        {
            throw new NotImplementedException();
        }

        public override Task<SalesChannelResponse> ToResponse(SalesChannel entity)
        {
            throw new NotImplementedException();
        }
    }
}