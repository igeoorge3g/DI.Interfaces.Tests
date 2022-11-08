using DI.Interfaces.Core.Integrations.Interfaces;
using DI.Interfaces.Core.Integrations.Models;

namespace DI.Interfaces.Integrations.Interfaces
{
    public interface IShopifyManager : IIntegrationManager<ShopifyAuth, ShopifyProduct>
    {
    }
}
