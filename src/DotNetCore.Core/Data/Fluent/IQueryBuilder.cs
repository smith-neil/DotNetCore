using System;
using System.Linq;
using DotNetCore.Core.Domain;

namespace DotNetCore.Core.Data.Fluent
{
    public interface IQueryBuilder<out T, out TQueryBuilder> : IQueryable<T>, IQueryable
        where T : BaseEntity
        where TQueryBuilder : class
    {
        TQueryBuilder ById(int id);
        TQueryBuilder ByDateCreated(DateTime dateCreated);
        TQueryBuilder ByMinDateCreated(DateTime minDateCreated);
        TQueryBuilder ByMaxDateCreated(DateTime maxDateCreated);
        TQueryBuilder ByDateLastModified(DateTime dateLastModified);
        TQueryBuilder ByMinLastDateModified(DateTime minDateLastModified);
        TQueryBuilder ByMaxLastDateModified(DateTime maxDateLastModified);

        TQueryBuilder After(int id);
        TQueryBuilder Before(int id);
    }
}
