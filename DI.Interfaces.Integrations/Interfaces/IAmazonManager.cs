using DI.Interfaces.Core.Integrations.Interfaces;
using DI.Interfaces.Core.Integrations.Models;

namespace DI.Interfaces.Integrations.Interfaces
{
    public interface IAmazonManager : IIntegrationManager<AmazonAuth, AmazonProduct>
    {
    }
}
