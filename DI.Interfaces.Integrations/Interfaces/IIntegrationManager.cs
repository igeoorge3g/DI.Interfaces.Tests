using DI.Interfaces.Core.Models;
using DI.Interfaces.Core.ViewModels;

namespace DI.Interfaces.Core.Integrations.Interfaces
{
    public interface IIntegrationManager<Auth, IntegrationPublication>
        where Auth : IAuth
        where IntegrationPublication : IPublication
    {
        Auth GetAuth(SalesChannel salesChanel);
        IntegrationPublication Publication_Create(Auth auth, Publication publication);
        Task<IntegrationPublication> Publication_Get(Auth auth, string identifier);
        Task<IEnumerable<IPublication>> Publication_Get_All(Auth auth);


        Task<PublicationRequest> ToPublicationRequest(IntegrationPublication publication);
    }
}
