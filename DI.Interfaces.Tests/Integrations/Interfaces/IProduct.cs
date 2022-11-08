namespace DI.Interfaces.Tests.Integrations.Interfaces
{
    /// <summary>
    /// Product Interface to Handle multiple Product Types (Amazon, Shopify, Woocommerce)
    /// </summary>
    public interface IPublication
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
