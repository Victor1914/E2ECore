namespace E2E.Core.Utils.Extensions
{
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces.Infrastructure;
    using Interfaces.Services;

    public static class CommonExtensions
    {
        public static async Task StoreResponse<TResponse>(this IResponseService responseService, HttpResponseMessage httpResponse, IJsonSerializer jsonSerializer)
            where TResponse : class
        {
            var response = jsonSerializer.Deserialize<TResponse>(await httpResponse.Content.ReadAsStringAsync());

            responseService.SetResponse(response);
            responseService.SetResponse(httpResponse);
        }

        public static StringContent CreateRequestBody<TRequest>(this TRequest content, IJsonSerializer jsonSerializer)
            where TRequest : class
        {
            return new StringContent(jsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
        }
    }
}