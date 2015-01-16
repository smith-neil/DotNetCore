using DotNetCore.Core.Security.Models;
using DotNetCore.Core.Utilities;
using DotNetCore.Data.EntityFramework.Identity.Models;

namespace DotNetCore.Data.EntityFramework.Identity.Utilities
{
    public static class IdentityModelFactoryUtils
    {
        public static Role CopyFrom(this Role source, AppRole identityRole)
        {
            source.ThrowIfNull("source");
            identityRole.ThrowIfNull("identityRole");

            source.Id = identityRole.Id;
            source.Name = identityRole.Name;
            foreach (var userRole in identityRole.Users)
                source.Users.Add(IdentityModelFactory.Create(userRole));

            return source;
        }

        public static User CopyFrom(this User source, AppUser identityUser)
        {
            source.ThrowIfNull("source");
            identityUser.ThrowIfNull("identityUser");

            source.Id = identityUser.Id;
            source.UserName = identityUser.UserName;
            source.Email = identityUser.Email;
            source.EmailConfirmed = identityUser.EmailConfirmed;
            source.PhoneNumber = identityUser.PhoneNumber;
            source.PhoneNumberConfirmed = identityUser.PhoneNumberConfirmed;
            source.AccessFailedCount = identityUser.AccessFailedCount;
            source.LockoutEnabled = identityUser.LockoutEnabled;
            source.LockoutEndDateUtc = identityUser.LockoutEndDateUtc;
            source.PasswordHash = identityUser.PasswordHash;
            source.SecurityStamp = identityUser.SecurityStamp;
            source.TwoFactorEnabled = identityUser.TwoFactorEnabled;

            foreach (var userRole in identityUser.Roles)
                source.Roles.Add(IdentityModelFactory.Create(userRole));
            foreach (var userLogin in identityUser.Logins)
                source.Logins.Add(IdentityModelFactory.Create(userLogin));
            foreach (var userClaim in identityUser.Claims)
                source.Claims.Add(IdentityModelFactory.Create(userClaim));

            return source;
        }
    }
}
