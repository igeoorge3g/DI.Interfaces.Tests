using DI.Interfaces.Core.Integrations.Interfaces;
using DI.Interfaces.Core.Integrations.Models;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;
using DI.Interfaces.Integrations.Interfaces;

namespace DI.Interfaces.Core.Integrations.Managers
{
    public class ShopifyManager : IShopifyManager
    {
        public ShopifyProduct Publication_Create(ShopifyAuth auth, Publication publication)
        {
            throw new NotImplementedException();
        }

        public ShopifyAuth GetAuth(SalesChannel salesChanel)
        {
            return new ShopifyAuth { Token = $"{salesChanel.Id}-{salesChanel.Name}" };
        }

        public Task<ShopifyProduct> Publication_Get(ShopifyAuth auth, string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IPublication>> Publication_Get_All(ShopifyAuth auth)
        {
            throw new NotImplementedException();
        }

        public Task<PublicationRequest> ToPublicationRequest(ShopifyProduct publication)
        {
            throw new NotImplementedException();
        }




    }
}
