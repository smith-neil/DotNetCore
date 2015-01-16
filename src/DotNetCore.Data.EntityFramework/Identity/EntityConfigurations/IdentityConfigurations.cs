using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DotNetCore.Data.EntityFramework.Identity.Models;

namespace DotNetCore.Data.EntityFramework.Identity.EntityConfigurations
{
    public static class IdentityConfigurations
    {
        public static void Configure(this EntityTypeConfiguration<AppUser> source)
        {
            source
                .ToTable("IdentityUser")
                .Property(m => m.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        public static void Configure(this EntityTypeConfiguration<AppRole> source)
        {
            source
                .ToTable("IdentityRole")
                .Property(m => m.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        public static void Configure(this EntityTypeConfiguration<AppUserRole> source)
        {
            source
                .ToTable("IdentityUserRole");
        }

        public static void Configure(this EntityTypeConfiguration<AppUserLogin> source)
        {
            source
                .ToTable("IdentityUserLogin");
        }

        public static void Configure(this EntityTypeConfiguration<AppUserClaim> source)
        {
            source
                .ToTable("IdentityUserClaim")
                .Property(m => m.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
