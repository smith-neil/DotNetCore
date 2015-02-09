using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DotNetCore.Core.Data.Fluent;
using DotNetCore.Core.Domain;
using DotNetCore.Core.Utilities;

namespace DotNetCore.Data.EntityFramework.Fluent
{
    public abstract class QueryBuilder<T, TQueryBuilder> : IQueryBuilder<T, TQueryBuilder>
        where T : BaseEntity
        where TQueryBuilder : class
    {
        protected QueryBuilder(IQueryable<T> query)
        {
            query.ThrowIfNull("query");

            Query = query;
        }

        protected IQueryable<T> Query { get; set; }

        public TQueryBuilder ById(int id)
        {
            Query = Query.Where(m => m.Id == id);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByDateCreated(DateTime dateCreated)
        {
            Query = Query.Where(m => m.DateCreated == dateCreated);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByMinDateCreated(DateTime minDateCreated)
        {
            Query = Query.Where(m => m.DateCreated >= minDateCreated);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByMaxDateCreated(DateTime maxDateCreated)
        {
            Query = Query.Where(m => m.DateCreated <= maxDateCreated);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByDateLastModified(DateTime dateLastModified)
        {
            Query = Query.Where(m => m.DateLastModified == dateLastModified);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByMinLastDateModified(DateTime minDateLastModified)
        {
            Query = Query.Where(m => m.DateLastModified >= minDateLastModified);

            return this as TQueryBuilder;
        }

        public TQueryBuilder ByMaxLastDateModified(DateTime maxDateLastModified)
        {
            Query = Query.Where(m => m.DateLastModified <= maxDateLastModified);

            return this as TQueryBuilder;
        }

        public TQueryBuilder After(int id)
        {
            Query = Query.Where(m => m.Id > id);

            return this as TQueryBuilder;
        }

        public TQueryBuilder Before(int id)
        {
            Query = Query.Where(m => m.Id < id);

            return this as TQueryBuilder;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { return Query.Expression; }
        }

        public Type ElementType
        {
            get { return Query.ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return Query.Provider; }
        }
    }
}
