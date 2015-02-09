using System;
using System.Collections.Generic;
using System.Data.Entity;
using DotNetCore.Core.Data.Fluent;
using DotNetCore.Core.Domain;
using DotNetCore.Core.Utilities;

namespace DotNetCore.Data.EntityFramework.Fluent
{
    public abstract class PersistableRepository<T> : IPersistableRepository<T>
        where T : BaseEntity
    {
        private readonly IDbContext _context;
        private bool _disposed;

        protected PersistableRepository(IDbContext context)
        {
            context.ThrowIfNull("context");

            _context = context;
            DbSet = context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; private set; }

        public void Insert(T entity)
        {
            entity.ThrowIfNull("entity");

            entity.DateCreated = DateTime.Now;
            _context.SetAsAdded(entity);
        }

        public void Insert(IEnumerable<T> entities)
        {
            entities.ThrowIfNull("entities");

            foreach (var entity in entities)
                Insert(entity);
        }

        public void Update(T entity)
        {
            entity.ThrowIfNull("entity");

            entity.DateLastModified = DateTime.Now;
            _context.SetAsModified(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            entities.ThrowIfNull("entities");

            foreach (var entity in entities)
                Update(entity);
        }

        public void Remove(T entity)
        {
            entity.ThrowIfNull("entity");

            _context.SetAsDeleted(entity);
        }

        public void Remove(IEnumerable<T> entities)
        {
            entities.ThrowIfNull("entities");

            foreach (var entity in entities)
                _context.SetAsModified(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
