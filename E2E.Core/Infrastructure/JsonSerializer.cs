namespace E2E.Core.Infrastructure
{
    using Interfaces.Infrastructure;
    using Newtonsoft.Json;

    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public TContract Deserialize<TContract>(string value)
        {
            return JsonConvert.DeserializeObject<TContract>(value);
        }
    }
}
