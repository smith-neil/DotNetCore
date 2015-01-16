using System.Data.Entity.ModelConfiguration;
using DotNetCore.Data.EntityFramework.Identity.Models;

namespace DotNetCore.Data.EntityFramework.Identity.EntityConfigurations
{
    public static class IdentityConfigurationHelpers
    {
        public static void IgnorePhone(this EntityTypeConfiguration<AppUser> source)
        {
            source
                .Ignore(m => m.PhoneNumber)
                .Ignore(m => m.PhoneNumberConfirmed);
        }
    }
}
