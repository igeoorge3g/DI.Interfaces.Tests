using DI.Interfaces.Tests.Integrations.Interfaces;
using DI.Interfaces.Tests.Integrations.Models;
using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.ViewModels;

namespace DI.Interfaces.Tests.Integrations.Managers
{
    public class MercadolibreManager : IIntegrationManager<MercadolibreAuth, MercadolibreProduct>
    {
        public MercadolibreProduct CreatePublication(MercadolibreAuth auth, Publication publication)
        {
            MercadolibreProduct response = Mercadolibre_RequestThatReturnConcretePublication(auth, publication);
            return response;
        }

        private MercadolibreProduct Mercadolibre_RequestThatReturnConcretePublication(MercadolibreAuth auth, Publication publication)
        {
            return new MercadolibreProduct { Id = 0, Name = "Producto de Mercadolibre", MercadolibreCustomProperty = "prop custom ML" };
        }

        public MercadolibreProduct CreatePublicationAndDoSomethingElseForAllSalesChannels(MercadolibreAuth auth, Publication publication)
        {
            var mercadolibrePublication = CreatePublication(auth, publication);
            mercadolibrePublication.MercadolibreCustomProperty = "chau";
            return mercadolibrePublication;
        }

        public MercadolibreAuth GetAuth(SalesChannel salesChanel)
        {
            return new MercadolibreAuth { ConnectionString = Guid.Empty };
        }

        public Task<MercadolibreProduct> GetPublication(MercadolibreAuth auth, string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<PublicationRequest> ToPublicationRequest(MercadolibreProduct publication)
        {
            throw new NotImplementedException();
        }
    }
}
