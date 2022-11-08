using DI.Interfaces.Core.Integrations.Interfaces;
using DI.Interfaces.Core.Integrations.Models;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;
using DI.Interfaces.Integrations.Interfaces;

namespace DI.Interfaces.Core.Integrations.Managers
{
    public class AmazonManager : IAmazonManager
    {
        private readonly IApiClient _apiClient;

        public AmazonManager(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public AmazonAuth GetAuth(SalesChannel salesChanel)
        {
            return new AmazonAuth() { };
        }

        public AmazonProduct Publication_Create(AmazonAuth auth, Publication product)
        {
            throw new NotImplementedException();
        }

        public Task<AmazonProduct> Publication_Get(AmazonAuth auth, string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPublication>> Publication_Get_All(AmazonAuth auth)
        {
            throw new NotImplementedException();
        }

        public Task<PublicationRequest> ToPublicationRequest(AmazonProduct publication)
        {
            throw new NotImplementedException();
        }


    }
}
