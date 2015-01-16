using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.Core.Domain;

namespace DotNetCore.Data.EntityFramework
{
    public interface IDbContext : IDisposable
    {
        IDbSet<T> Set<T>() where T : BaseEntity;

        void SetAsAdded<T>(T entity) where T : BaseEntity;

        void SetAsModified<T>(T entity) where T : BaseEntity;

        void SetAsDeleted<T>(T entity) where T : BaseEntity;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        void BeginTransaction();

        int Commit();

        Task<int> CommitAsync();

        void Rollback();
    }
}
