using DI.Interfaces.Tests.Integrations.Interfaces;
using DI.Interfaces.Tests.Integrations.Managers;
using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.ViewModels;

namespace DI.Interfaces.Tests.Manager
{
    /// <summary>
    /// Ive created this <IntegrationManager> to hide all Concrete Managers and Inject into the controllers 
    /// as a single class that wraps all managers because i dont know the concrete type to be used
    /// This service will alse be injected as <Scoped>
    /// </summary>
    public class IntegrationManager
    {
        private readonly AmazonManager _amazon;
        private readonly ShopifyManager _shopify;
        private readonly MercadolibreManager _mercadolibre;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amazon">Amazon <Scoped> service will be injected</param>
        /// <param name="shopify">Shopify <Scoped> service will be injected</param>
        /// <param name="mercadolibre">Mercadolibre <Scoped> service will be injected</param>
        public IntegrationManager(AmazonManager amazon, ShopifyManager shopify, MercadolibreManager mercadolibre)
        {
            _amazon = amazon;
            _shopify = shopify;
            _mercadolibre = mercadolibre;
        }

        /// <summary>
        /// Private method to get the Concrete Manager based on the SalesChannel type (for this example its the name)
        /// </summary>
        /// <param name="salesChannel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private IIntegrationManager<IAuth, IPublication> GetConcrete(SalesChannel salesChannel)
        {
            switch (salesChannel.Name)
            {
                case "Amazon":
                    return (IIntegrationManager<IAuth, IPublication>)_amazon;          // <<< Cast is needed
                case "Shopify":
                    return (IIntegrationManager<IAuth, IPublication>)_shopify;         // <<< Cast is needed
                case "Mercadolibre":
                    return (IIntegrationManager<IAuth, IPublication>)_mercadolibre;    // <<< Cast is needed
                default:
                    throw new NotImplementedException(salesChannel.Name);
            }
        }

        public IPublication CreatePublication_Wrapper(SalesChannel salesChannel, Publication publication)
        {
            var interfaceHiddenConcreteManager = GetConcrete(salesChannel);
            var interfaceHiddenConcreteAuth = interfaceHiddenConcreteManager.GetAuth(salesChannel);
            var interfaceHiddenConcreteProduct = interfaceHiddenConcreteManager.CreatePublication(interfaceHiddenConcreteAuth, publication);
            return interfaceHiddenConcreteProduct;
        }

        public IPublication CreatePublicationAndDoSomethingElseForAllSalesChannels(SalesChannel salesChannel, Publication publication)
        {
            var interfaceHiddenConcreteManager = GetConcrete(salesChannel);
            var interfaceHiddenConcreteAuth = interfaceHiddenConcreteManager.GetAuth(salesChannel);
            var interfaceHiddenConcreteProduct = interfaceHiddenConcreteManager.CreatePublication(interfaceHiddenConcreteAuth, publication);
            return interfaceHiddenConcreteProduct;
        }

        internal Task<IPublication> Publication_GetByIdentifier(SalesChannel salesChannel, string identifier)
        {
            var auth = GetConcrete(salesChannel).GetAuth(salesChannel);
            return Task.Run(() =>
            {
                return GetConcrete(salesChannel).GetPublication(auth, identifier);
            });
        }

        internal Task<PublicationRequest> ToPublicationRequest(SalesChannel salesChannel, IPublication publication)
        {
            return GetConcrete(salesChannel).ToPublicationRequest(publication);
        }
    }
}
