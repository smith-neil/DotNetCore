using DotNetCore.Core.Domain;

namespace DotNetCore.Core.Data
{
    public interface IQueryableRepository<TEntity, out TQueryBuilder>
        where TEntity : BaseEntity
        where TQueryBuilder : class, IQueryBuilder<TEntity, TQueryBuilder>
    {
        TQueryBuilder Query();
    }
}
