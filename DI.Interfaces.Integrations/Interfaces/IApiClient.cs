using DI.Interfaces.Core.Integrations.Interfaces;

namespace DI.Interfaces.Integrations.Interfaces
{
    public interface IApiClient
    {
        Task<IApiResponse<IPublication>> Publication_Get(string identifier);
        Task<IApiResponse<IEnumerable<IPublication>>> Publication_Get_All();
    }
}
