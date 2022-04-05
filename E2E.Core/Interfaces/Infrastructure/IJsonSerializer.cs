namespace E2E.Core.Interfaces.Infrastructure
{
    public interface IJsonSerializer
    {
        string Serialize(object value);

        TContract Deserialize<TContract>(string value);
    }
}
