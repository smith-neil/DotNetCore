using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using DotNetCore.Core.Domain;
using DotNetCore.Core.Utilities;

namespace DotNetCore.Data.EntityFramework
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        private ObjectContext _objectContext;
        private DbTransaction _transaction;

        protected BaseDbContext() : base("AppContext")
        {
            
        }

        protected BaseDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            
        }

        protected BaseDbContext(ILogger logger) : base("AppContext")
        {
            Database.Log = logger.Log;
        }

        protected BaseDbContext(string nameOrConnectionString, ILogger logger) : base(nameOrConnectionString)
        {
            Database.Log = logger.Log;
        }

        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }

        public void SetAsAdded<T>(T entity) where T : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        public void SetAsModified<T>(T entity) where T : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Modified);
        }

        public void SetAsDeleted<T>(T entity) where T : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Deleted);
        }

        public void BeginTransaction()
        {
            _objectContext = ((IObjectContextAdapter) this).ObjectContext;

            if (_objectContext.Connection.State == ConnectionState.Open)
                return;
            
            _objectContext.Connection.Open();
            _transaction = _objectContext.Connection.BeginTransaction();
        }

        public int Commit()
        {
            var count  = SaveChanges();
            _transaction.Commit();

            return count;
        }

        public async Task<int> CommitAsync()
        {
            var count = await SaveChangesAsync();
            _transaction.Commit();

            return count;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        private void UpdateEntityState<T>(T entity, EntityState state) where T : BaseEntity
        {
            var dbEntityEntry = GetDbEntry(entity);
            dbEntityEntry.State = state;
        }

        private DbEntityEntry GetDbEntry<T>(T entity) where T : BaseEntity
        {
            var dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
                Set<T>().Attach(entity);

            return dbEntityEntry;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                    _objectContext.Connection.Close();
                if (_objectContext != null)
                    _objectContext.Dispose();
                if (_transaction != null)
                    _transaction.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
