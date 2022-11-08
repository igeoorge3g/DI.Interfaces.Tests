using DI.Interfaces.Tests.Models;
using DI.Interfaces.Tests.ViewModels;

namespace DI.Interfaces.Tests.Integrations.Interfaces
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
