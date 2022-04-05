namespace E2E.Core.Interfaces.Infrastructure
{
    using System.Collections.Generic;

    public interface IBaseClient
    {
        void AddHeaders(Dictionary<string, string> headers);

        void AddHeader(string key, string value);

        void ClearHeader(string name);

        void ClearAllHeaders();
    }
}