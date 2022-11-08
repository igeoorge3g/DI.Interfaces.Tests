using DI.Interfaces.Core.Integrations.Interfaces;

namespace DI.Interfaces.Core.Integrations.Models
{


    /// <summary>
    /// Amazon Product
    /// </summary>
    public class AmazonProduct : IPublication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// This property belongs only to Amazon
        /// </summary>
        public string CustomAmazonProperty { get; set; }
        public string Identifier { get; set; }
    }

    public class ShopifyProduct : IPublication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// This property belongs only to Shopify
        /// </summary>
        public string CustomShopifyProperty { get; set; }
        public string Identifier { get; set; }
    }

    public class MercadolibreProduct : IPublication
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string MercadolibreCustomProperty { get; set; }
        public string Identifier { get; set; }
    }
}
