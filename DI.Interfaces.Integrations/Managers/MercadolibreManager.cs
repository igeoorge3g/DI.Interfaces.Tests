using DI.Interfaces.Core.Integrations.Interfaces;
using DI.Interfaces.Core.Integrations.Models;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;
using DI.Interfaces.Integrations.Interfaces;

namespace DI.Interfaces.Core.Integrations.Managers
{
    public class MercadolibreManager : IMercadolibreManager
    {
        private readonly IMercadolibreApiClient _apiClient;
        public MercadolibreManager(IMercadolibreApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public MercadolibreProduct Publication_Create(MercadolibreAuth auth, Publication publication)
        {
            throw new NotImplementedException();
        }

        public MercadolibreAuth GetAuth(SalesChannel salesChanel)
        {
            return new MercadolibreAuth { ConnectionString = Guid.Empty };
        }

        public Task<MercadolibreProduct> Publication_Get(MercadolibreAuth auth, string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPublication>> Publication_Get_All(MercadolibreAuth auth)
        {
            throw new NotImplementedException();
        }
        public Task<PublicationRequest> ToPublicationRequest(MercadolibreProduct publication)
        {
            throw new NotImplementedException();
        }
    }
}
