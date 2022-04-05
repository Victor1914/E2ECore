namespace E2E.Core.Business.Services
{
    using System;
    using System.Collections.Generic;
    using Interfaces.Services;

    public class ResponseService : TestEntityService, IResponseService
    {
        public TResponse GetResponse<TResponse>(int id = 0) where TResponse : class => GetTestEntity<TResponse>(id);

        public bool AnyResponse<TResponse>(int id = 0) where TResponse : class => AnyTestEntity<TResponse>(id);

        public TResponse GetResponse<TResponse>(Func<TResponse, bool> predicate) where TResponse : class => GetTestEntity(predicate);

        public bool AnyResponse<TResponse>(Func<TResponse, bool> predicate) where TResponse : class => AnyTestEntity(predicate);

        public List<TResponse> GetResponses<TResponse>(Func<TResponse, bool> predicate = null) where TResponse : class => GetTestEntities(predicate);

        public void SetResponse<TResponse>(TResponse response) where TResponse : class => SetTestEntity(response);

        public bool RemoveResponse<TRequest>(int id) where TRequest : class => RemoveTestEntity<TRequest>(id);

        public void ClearAllResponses() => ClearAllEntities();
    }
}
