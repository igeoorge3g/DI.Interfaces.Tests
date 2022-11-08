﻿#nullable disable
using DI.Interfaces.Tests.Interfaces;
using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.Repositories;
using DI.Interfaces.Tests.ViewModels;

namespace DI.Interfaces.Tests.Manager
{
    public class SalesChannelManager : BaseManager<int, SalesChannel, SalesChannelRequest>, ISalesChannelManager
    {
        new protected SalesChannelRepository _repository;
        public SalesChannelManager(ISalesChannelRepository repository) : base(repository)
        {
        }

        protected override Task<SalesChannel> ToEntity(SalesChannelRequest request)
        {
            throw new NotImplementedException();
        }

        protected override Task<SalesChannelRequest> ToRequest(SalesChannel entity)
        {
            throw new NotImplementedException();
        }
    }
}