using System.Collections.Generic;
using DotNetCore.Core.Data;
using DotNetCore.Core.Domain;

namespace DotNetCore.Data.EntityFramework
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepositroy<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext _context;

        public Repository(IDbContext context) : base(context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.SetAsAdded(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.SetAsModified(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.SetAsDeleted(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                Remove(entity);
        }
    }
}
