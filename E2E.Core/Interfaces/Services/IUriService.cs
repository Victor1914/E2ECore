namespace E2E.Core.Interfaces.Services
{
    using System;

    public interface IUriService
    {
        Uri Create(string serviceMethod, string additionalParams = null);

        Uri CreateFull(string serviceName, string serviceMethod, string additionalParams = null);

        Uri CreateMain(string serviceName);
    }
}