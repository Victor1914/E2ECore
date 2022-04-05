namespace E2E.Core.Models.Configurations
{
    using Microsoft.AspNetCore.Http.Connections;

    public class SignalRSettings
    {
        /// <summary>
        /// Hub connection timeout in minutes
        /// </summary>
        public int ConnectionTimeout { get; set; }

        public HttpTransportType HttpTransportType { get; set; }
    }
}