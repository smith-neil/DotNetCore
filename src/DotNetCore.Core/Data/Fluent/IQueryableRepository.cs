using DotNetCore.Core.Domain;

namespace DotNetCore.Core.Data.Fluent
{
    public interface IQueryableRepository<TEntity, out TQueryBuilder>
        where TEntity : BaseEntity
        where TQueryBuilder : class, IQueryBuilder<TEntity, TQueryBuilder>
    {
        TQueryBuilder Query();
    }
}
