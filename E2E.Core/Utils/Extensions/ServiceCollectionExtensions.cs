namespace E2E.Core.Utils.Extensions
{
    using Business.Services;
    using Infrastructure;
    using Infrastructure.WebClients;
    using Interfaces.Infrastructure;
    using Interfaces.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddE2ECore(this IServiceCollection services)
        {
            return services
                .AddServices()
                .AddWebClients()
                .AddSerializers();
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IUriService, UriService>()
                .AddSingleton<IRequestService, RequestService>()
                .AddSingleton<IResponseService, ResponseService>();
        }

        private static IServiceCollection AddWebClients(this IServiceCollection services)
        {
            return services
                .AddSingleton<IRestClient, RestClient>()
                .AddSingleton<ISignalRClient, SignalRClient>();
        }

        private static IServiceCollection AddSerializers(this IServiceCollection services)
        {
            return services.AddSingleton<IJsonSerializer, JsonSerializer>();
        }
    }
}
