namespace E2E.Core.Interfaces.Services
{
    using System;
    using System.Collections.Generic;

    public interface IResponseService
    {
        TResponse GetResponse<TResponse>(int id = 0) where TResponse : class;

        bool AnyResponse<TResponse>(int id = 0) where TResponse : class;

        TResponse GetResponse<TResponse>(Func<TResponse, bool> predicate) where TResponse : class;

        bool AnyResponse<TResponse>(Func<TResponse, bool> predicate) where TResponse : class;

        List<TResponse> GetResponses<TResponse>(Func<TResponse, bool> predicate = null) where TResponse : class;

        void SetResponse<TResponse>(TResponse response) where TResponse : class;

        bool RemoveResponse<TRequest>(int id) where TRequest : class;

        void ClearAllResponses();
    }
}