using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Core.Domain;

namespace DotNetCore.Core.Data
{
    public interface IReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> AsQueryable();

        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
