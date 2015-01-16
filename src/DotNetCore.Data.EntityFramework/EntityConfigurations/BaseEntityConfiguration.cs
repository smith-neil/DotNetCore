using System.Data.Entity.ModelConfiguration;
using DotNetCore.Core.Domain;

namespace DotNetCore.Data.EntityFramework.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : EntityTypeConfiguration<T>
        where T : BaseEntity
    {
        protected BaseEntityConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.DateCreated)
                .IsRequired();

            Property(x => x.DateLastModified)
                .IsOptional();
        }
    }
}
