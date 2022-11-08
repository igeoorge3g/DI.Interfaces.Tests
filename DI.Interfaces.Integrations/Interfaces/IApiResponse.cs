namespace DI.Interfaces.Integrations.Interfaces
{

    public interface IApiResponse<T> : IApiResponse
    {
        public T Data { get; set; }
    }

    public interface IApiResponse
    {
        public bool Success { get; set; }
    }

}
