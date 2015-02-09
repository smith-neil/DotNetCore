using System;
using System.Collections.Generic;
using DotNetCore.Core.Domain;

namespace DotNetCore.Core.Data.Fluent
{
    public interface IPersistableRepository<in T> : IDisposable
        where T : BaseEntity
    {
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Remove(T entity);
        void Remove(IEnumerable<T> entities);
    }
}
