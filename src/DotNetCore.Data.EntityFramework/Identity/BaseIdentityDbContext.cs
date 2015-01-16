
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using DotNetCore.Core.Domain;
using DotNetCore.Core.Utilities;
using DotNetCore.Data.EntityFramework.Identity.EntityConfigurations;
using DotNetCore.Data.EntityFramework.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DotNetCore.Data.EntityFramework.Identity
{
    public abstract class BaseIdentityDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>, IDbContext
    {
        private ObjectContext _objectContext;
        private DbTransaction _transaction;

        protected BaseIdentityDbContext() : base("AppContext")
        {
            
        }

        protected BaseIdentityDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            
        }

        protected BaseIdentityDbContext(ILogger logger) : base("AppContext")
        {
            Database.Log = logger.Log;
        }

        protected BaseIdentityDbContext(string nameOrConnectionString, ILogger logger)
            : base(nameOrConnectionString)
        {
            Database.Log = logger.Log;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().Configure();
            modelBuilder.Entity<AppRole>().Configure();
            modelBuilder.Entity<AppUserRole>().Configure();
            modelBuilder.Entity<AppUserLogin>().Configure();
            modelBuilder.Entity<AppUserClaim>().Configure();

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Modified);
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity
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

        private void UpdateEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : BaseEntity
        {
            var dbEntityEntry = GetDbEntry(entity);
            dbEntityEntry.State = state;
        }

        private DbEntityEntry GetDbEntry<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
                Set<TEntity>().Attach(entity);

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
