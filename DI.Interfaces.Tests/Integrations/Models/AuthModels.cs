using DI.Interfaces.Tests.Integrations.Interfaces;

namespace DI.Interfaces.Tests.Integrations.Models
{
    /// <summary>
    /// Amazon authentication Class
    /// </summary>
    public class AmazonAuth : IAuth
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Shopify authentication Class
    /// </summary>
    public class ShopifyAuth : IAuth
    {
        public string Token { get; set; }
    }

    /// <summary>
    /// Mercadolibre authentication Class
    /// </summary>
    public class MercadolibreAuth : IAuth
    {
        public Guid ConnectionString { get; set; }
    }
}
