namespace E2E.Core.Business.RequestBuilders
{
    using Interfaces.RequestBuilders;
    using Interfaces.Services;

    public abstract class BaseRequestBuilder<TRequest> : IBaseRequestBuilder
        where TRequest : class, new()
    {
        protected TRequest Request;
        protected readonly IRequestService RequestService;

        protected BaseRequestBuilder(IRequestService requestService)
        {
            RequestService = requestService;
        }

        public void CreateRequest()
        {
            Request = new TRequest();
        }

        public void Build()
        {
            RequestService.SetRequest(Request);
        }
    }
}
