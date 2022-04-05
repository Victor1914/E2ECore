namespace E2E.Core.Infrastructure.WebClients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces.Infrastructure;
    using Interfaces.Services;
    using Microsoft.AspNetCore.SignalR.Client;
    using Models.Configurations;

    public class SignalRClient : ISignalRClient
    {
        private readonly IRequestService _requestService;
        private readonly IResponseService _responseService;
        private readonly IUriService _uriService;
        private readonly SignalRSettings _signalRSettings;

        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();

        public SignalRClient(
            IRequestService requestService,
            IResponseService responseService,
            IUriService uriService,
            SignalRSettings signalRSettings)
        {
            _requestService = requestService;
            _responseService = responseService;
            _uriService = uriService;
            _signalRSettings = signalRSettings;
        }

        public async Task InvokeRequestAsync<TRequest, TResponse>(string serviceMethod, string serviceName = null, int requestId = 0)
            where TRequest : class
            where TResponse : class
        {
            var connection = CreateHubConnection(serviceName);
            await connection.StartAsync();

            var requestBody = _requestService.GetRequest<TRequest>(requestId);
            var response = await connection.InvokeAsync<TResponse>(serviceMethod, requestBody);
            _responseService.SetResponse(response);

            await connection.StopAsync();
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
            _headers.TryAdd(key, value);
        }

        public void ClearHeader(string name)
        {
            _headers.Remove(name);
        }

        public void ClearAllHeaders()
        {
            _headers.Clear();
        }

        private HubConnection CreateHubConnection(string serviceName)
        {
            return new HubConnectionBuilder()
                .WithUrl(_uriService.CreateMain(serviceName), _signalRSettings.HttpTransportType,
                    options =>
                    {
                        options.CloseTimeout = TimeSpan.FromSeconds(_signalRSettings.ConnectionTimeout);
                        options.Headers = _headers;
                    })
                .Build();
        }
    }
}