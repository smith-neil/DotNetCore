using System;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.Core.Data;
using DotNetCore.Core.Data.Fluent;
using DotNetCore.Core.Utilities;

namespace DotNetCore.Data.EntityFramework
{
    public abstract class BaseUnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private bool _disposed;

        protected BaseUnitOfWork(IDbContext context)
        {
            context.ThrowIfNull("context");

            _context = context;
            _disposed = false;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public int Commit()
        {
            return _context.Commit();
        }

        public void Rollback()
        {
            _context.Rollback();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.CommitAsync();
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
