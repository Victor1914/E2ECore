namespace E2E.Core.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.Models;
    using Models.Entities;

    public abstract class TestEntityService
    {
        private readonly List<ITestEntity> _entities = new List<ITestEntity>();

        protected TEntity GetTestEntity<TEntity>(int id = 0) where TEntity : class
        {
            var responses = _entities.Where(entity => entity.Name == typeof(TEntity).Name);

            if (id > 0)
                responses = responses.Where(e => e.Id == id);

            return (TEntity)responses.FirstOrDefault()?.Entity;
        }

        protected bool AnyTestEntity<TEntity>(int id = 0) where TEntity : class
        {
            return GetTestEntity<TEntity>(id) != null;
        }

        protected TEntity GetTestEntity<TEntity>(Func<TEntity, bool> predicate)
        {
            return (TEntity)_entities
                .Where(entity => entity.Name == typeof(TEntity).Name)
                .Select(e => e.Entity)
                .FirstOrDefault(entity => predicate(entity));
        }

        protected bool AnyTestEntity<TEntity>(Func<TEntity, bool> predicate)
        {
            return _entities
                .Where(entity => entity.Name == typeof(TEntity).Name)
                .Select(e => e.Entity)
                .Any(entity => predicate(entity));
        }

        protected List<TEntity> GetTestEntities<TEntity>(Func<TEntity, bool> predicate = null)
        {
            var responses = _entities
                .Where(entity => entity.Name == typeof(TEntity).Name)
                .Select(e => e.Entity)
                .Cast<TEntity>();

            if (predicate != null)
                responses = responses.Where(predicate);

            return responses.ToList();
        }

        protected void SetTestEntity<TEntity>(TEntity entity) where TEntity : class
        {
            var name = typeof(TEntity).Name;
            var id = _entities.Count(e => e.Name == name) + 1;

            var testEntity = new TestEntity
            {
                Id = id,
                Name = name,
                Entity = entity
            };

            _entities.Add(testEntity);
        }

        protected bool RemoveTestEntity<TEntity>(int id) where TEntity : class
        {
            var itemToRemove = _entities.SingleOrDefault(e => e.Name == typeof(TEntity).Name && e.Id == id);

            return itemToRemove != null && _entities.Remove(itemToRemove);
        }

        public void ClearAllEntities() => _entities.Clear();
    }
}
