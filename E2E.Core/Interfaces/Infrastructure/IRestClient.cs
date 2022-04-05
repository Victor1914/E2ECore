namespace E2E.Core.Interfaces.Infrastructure
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public interface IRestClient : IBaseClient
    {
        Task SendRequestAsync<TRequest, TSuccessResponse, TErrorResponse>(Uri uri, HttpMethod httpMethod, int requestId = 0)
            where TRequest : class
            where TSuccessResponse : class
            where TErrorResponse : class;

        Task SendRequestAsync<TSuccessResponse, TErrorResponse>(Uri uri, HttpMethod httpMethod)
            where TSuccessResponse : class
            where TErrorResponse : class;
    }
}