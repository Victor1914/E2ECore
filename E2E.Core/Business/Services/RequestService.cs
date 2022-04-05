namespace E2E.Core.Business.Services
{
    using System;
    using System.Collections.Generic;
    using Interfaces.Services;

    public class RequestService : TestEntityService, IRequestService
    {
        public TRequest GetRequest<TRequest>(int id = 0) where TRequest : class => GetTestEntity<TRequest>(id);

        public bool AnyRequest<TRequest>(int id = 0) where TRequest : class => AnyTestEntity<TRequest>(id);

        public TRequest GetRequest<TRequest>(Func<TRequest, bool> predicate) where TRequest : class => GetTestEntity(predicate);

        public bool AnyRequest<TRequest>(Func<TRequest, bool> predicate) where TRequest : class => AnyTestEntity(predicate);

        public List<TRequest> GetRequests<TRequest>(Func<TRequest, bool> predicate = null) where TRequest : class => GetTestEntities(predicate);

        public void SetRequest<TRequest>(TRequest request) where TRequest : class => SetTestEntity(request);

        public bool RemoveRequest<TRequest>(int id) where TRequest : class => RemoveTestEntity<TRequest>(id);

        public void ClearAllRequests() => ClearAllEntities();
    }
}