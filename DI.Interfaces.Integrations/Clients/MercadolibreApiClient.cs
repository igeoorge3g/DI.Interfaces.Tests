using DI.Interfaces.Core.Integrations.Interfaces;
using DI.Interfaces.Integrations.Interfaces;

namespace DI.Interfaces.Integrations.Clients
{
    public class MercadolibreApiClient : IMercadolibreApiClient
    {
        public MercadolibreApiClient()
        {

        }

        public Task<IApiResponse<IPublication>> Publication_Get(string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<IEnumerable<IPublication>>> Publication_Get_All()
        {
            throw new NotImplementedException();
        }
    }
}
