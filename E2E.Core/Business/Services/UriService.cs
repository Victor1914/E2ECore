namespace E2E.Core.Business.Services
{
    using System;
    using Interfaces.Services;
    using Models.Configurations;

    public class UriService : IUriService
    {
        private readonly AppUrls _appUrls;

        public UriService(AppUrls appUrls)
        {
            _appUrls = appUrls;
        }

        public Uri Create(string serviceMethod, string additionalParams = null)
        {
            return CreateUri(_appUrls.ServiceUnderTest, serviceMethod, additionalParams);
        }

        public Uri CreateFull(string serviceName, string serviceMethod, string additionalParams = null)
        {
            return CreateUri(serviceName, serviceMethod, additionalParams);
        }

        public Uri CreateMain(string serviceName)
        {
            return CreateUri(serviceName);
        }

        private Uri CreateUri(string serviceName = null, string serviceMethod = null, string additionalParams = null)
        {
            return new Uri($"{CreateBase()}/{serviceName}/{serviceMethod}{additionalParams}");
        }

        private string CreateBase()
        {
            var baseUrl = _appUrls.BaseUrl;

            return $"{baseUrl.Scheme}://{baseUrl.Host}:{baseUrl.Port}";
        }
    }
}