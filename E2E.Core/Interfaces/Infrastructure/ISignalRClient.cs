namespace E2E.Core.Interfaces.Infrastructure
{
    using System.Threading.Tasks;

    public interface ISignalRClient : IBaseClient
    {
        Task InvokeRequestAsync<TRequest, TResponse>(string serviceMethod, string serviceName = null, int requestId = 0)
            where TRequest : class
            where TResponse : class;
    }
}