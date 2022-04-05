namespace E2E.Core.Models.Configurations
{
    public class BaseUrl
    {
        public string Scheme { get; set; } = "http";

        public string Host { get; set; }

        public int Port { get; set; }
    }
}