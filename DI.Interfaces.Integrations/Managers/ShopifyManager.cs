using DI.Interfaces.Core.Integrations.Interfaces;
using DI.Interfaces.Core.Integrations.Models;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Integrations.Managers
{
    public class ShopifyManager : IIntegrationManager<ShopifyAuth, ShopifyProduct>
    {
        public ShopifyProduct CreatePublication(ShopifyAuth auth, Publication publication)
        {
            ShopifyProduct response = Shopify_RequestThatReturnConcreteProduct(auth, publication);

            return response;
        }

        public ShopifyProduct CreatePublicationAndDoSomethingElseForAllSalesChannels(ShopifyAuth auth, Publication publication)
        {
            var createdShopifyProduct = CreatePublication(auth, publication);
            var updatedAmazonProduct = Other_Shopify_MethodThatRequiresCustomProperty(auth, createdShopifyProduct);

            return updatedAmazonProduct;
        }
        public ShopifyAuth GetAuth(SalesChannel salesChanel)
        {
            return new ShopifyAuth { Token = $"{salesChanel.Id}-{salesChanel.Name}" };
        }


        private ShopifyProduct Shopify_RequestThatReturnConcreteProduct(ShopifyAuth auth, Publication publication)
        {
            return new ShopifyProduct();
        }

        private ShopifyProduct Other_Shopify_MethodThatRequiresCustomProperty(ShopifyAuth auth, ShopifyProduct createdShopifyPublication)
        {
            createdShopifyPublication.CustomShopifyProperty = "xxxxx";
            return createdShopifyPublication;
        }

        public Task<ShopifyProduct> GetPublication(ShopifyAuth auth, string identifier)
        {
            throw new NotImplementedException();
        }

        public Task<PublicationRequest> ToPublicationRequest(ShopifyProduct publication)
        {
            throw new NotImplementedException();
        }
    }
}
