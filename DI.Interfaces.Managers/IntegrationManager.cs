#nullable disable

using DI.Interfaces.Core.Integrations.Interfaces;
using DI.Interfaces.Core.Integrations.Managers;
using DI.Interfaces.Core.Interfaces;
using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Manager
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
        private readonly IPublicationManager _publicationManager;
        private readonly ISalesChannelManager _salesChannelManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amazon">Amazon <Scoped> service will be injected</param>
        /// <param name="shopify">Shopify <Scoped> service will be injected</param>
        /// <param name="mercadolibre">Mercadolibre <Scoped> service will be injected</param>
        public IntegrationManager(
            AmazonManager amazon,
            ShopifyManager shopify,
            MercadolibreManager mercadolibre,
            IPublicationManager publicationManager,
            ISalesChannelManager salesChannelManager)
        {
            _amazon = amazon;
            _shopify = shopify;
            _mercadolibre = mercadolibre;
            _publicationManager = publicationManager;
            _salesChannelManager = salesChannelManager;
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

        public async Task<PublicationResponse> Sync(int publicationId)
        {
            var publication = await _publicationManager.Find(publicationId);
            var salesChannel = await _salesChannelManager.Find(publication.SalesChannelId);

            var publicationResponse = await Publication_GetByIdentifier(salesChannel, publication.Identifier);
            var publicationRequest = await ToPublicationRequest(salesChannel, publicationResponse!);

            return await _publicationManager.Update(publication, publicationRequest);
        }

        public async Task<PublicationResponse> Sync(int salesChannelId, string identifier)
        {
            var salesChannel = await _salesChannelManager.Find(salesChannelId);
            var publicationResponse = await Publication_GetByIdentifier(salesChannel, identifier);

            PublicationRequest publicationRequest = await ToPublicationRequest(salesChannel, publicationResponse!);

            Publication publication = await _publicationManager.FindByIdentifier(salesChannelId, identifier);
            if (publication is null)
            {
                return await _publicationManager.Insert(publicationRequest);
            }

            return await _publicationManager.Update(publication, publicationRequest);
        }
    }
}
