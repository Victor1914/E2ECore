namespace E2E.Core.Interfaces.Services
{
    using System;
    using System.Collections.Generic;

    public interface IRequestService
    {
        TRequest GetRequest<TRequest>(int id = 0) where TRequest : class;

        bool AnyRequest<TRequest>(int id = 0) where TRequest : class;

        TRequest GetRequest<TRequest>(Func<TRequest, bool> predicate) where TRequest : class;

        bool AnyRequest<TRequest>(Func<TRequest, bool> predicate) where TRequest : class;

        List<TRequest> GetRequests<TRequest>(Func<TRequest, bool> predicate = null) where TRequest : class;

        void SetRequest<TRequest>(TRequest request) where TRequest : class;

        bool RemoveRequest<TRequest>(int id) where TRequest : class;

        void ClearAllRequests();
    }
}