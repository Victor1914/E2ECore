namespace E2E.Core.Infrastructure.WebClients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Interfaces.Infrastructure;
    using Interfaces.Services;
    using Utils.Extensions;

    public class RestClient : IRestClient
    {
        private readonly IRequestService _requestService;
        private readonly IResponseService _responseService;
        private readonly IJsonSerializer _jsonSerializer;

        private readonly HttpClient _httpClient = new HttpClient();

        public RestClient(
            IRequestService requestService,
            IResponseService responseService,
            IJsonSerializer jsonSerializer)
        {
            _requestService = requestService;
            _responseService = responseService;
            _jsonSerializer = jsonSerializer;
        }

        public async Task SendRequestAsync<TRequest, TSuccessResponse, TErrorResponse>(Uri uri, HttpMethod httpMethod, int requestId = 0)
            where TRequest : class
            where TSuccessResponse : class
            where TErrorResponse : class
        {
            var requestBody = PrepareRequestBody<TRequest>(requestId);

            var response = await SendAsyncRequest(httpMethod, uri, requestBody);

            await StoreResponse<TSuccessResponse, TErrorResponse>(response);
        }

        public async Task SendRequestAsync<TSuccessResponse, TErrorResponse>(Uri uri, HttpMethod httpMethod)
            where TSuccessResponse : class
            where TErrorResponse : class
        {
            var response = await SendAsyncRequest(httpMethod, uri);

            await StoreResponse<TSuccessResponse, TErrorResponse>(response);
        }

        public void AddHeaders(Dictionary<string, string> headers)
        {
            foreach (var (key, value) in headers)
            {
                AddHeader(key, value);
            }
        }

        public void AddHeader(string key, string value)
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, value);
        }

        public void ClearHeader(string name)
        {
            _httpClient.DefaultRequestHeaders.Remove(name);
        }

        public void ClearAllHeaders()
        {
            _httpClient.DefaultRequestHeaders.Clear();
        }

        private async Task<HttpResponseMessage> SendAsyncRequest(HttpMethod method, Uri uri, HttpContent requestBody = null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = uri,
                Content = requestBody,
                Method = method
            };

            return await _httpClient.SendAsync(request);
        }

        private StringContent PrepareRequestBody<TRequest>(int requestId = 0)
            where TRequest : class
        {
            return _requestService
                .GetRequest<TRequest>(requestId)
                .CreateRequestBody(_jsonSerializer);
        }

        private async Task StoreResponse<TSuccessResponse, TErrorResponse>(HttpResponseMessage response)
            where TSuccessResponse : class
            where TErrorResponse : class
        {
            if (response.IsSuccessStatusCode)
            {
                await _responseService.StoreResponse<TSuccessResponse>(response, _jsonSerializer);
            }
            else
            {
                await _responseService.StoreResponse<TErrorResponse>(response, _jsonSerializer);
            }
        }
    }
}