using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Integrations.Interfaces
{

    /// <summary>
    /// Shared Methods for all SalesChannels (Amazon, Shopify, Woocommerce)
    /// </summary>
    public interface IIntegrationManager<Auth, SalesChannelProduct>
        where Auth : IAuth
        where SalesChannelProduct : IPublication
    {
        SalesChannelProduct CreatePublication(Auth auth, Publication publication);
        SalesChannelProduct CreatePublicationAndDoSomethingElseForAllSalesChannels(Auth auth, Publication publication);
        Task<SalesChannelProduct> GetPublication(Auth auth, string identifier);

        Auth GetAuth(SalesChannel salesChanel);
        Task<PublicationRequest> ToPublicationRequest(SalesChannelProduct publication);
    }
}
