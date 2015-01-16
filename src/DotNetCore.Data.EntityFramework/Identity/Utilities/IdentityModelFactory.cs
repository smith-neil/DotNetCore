using DotNetCore.Core.Security.Models;
using DotNetCore.Data.EntityFramework.Identity.Models;
using Microsoft.AspNet.Identity;
using UserLoginInfo = DotNetCore.Core.Security.Models.UserLoginInfo;

namespace DotNetCore.Data.EntityFramework.Identity.Utilities
{
    public class IdentityModelFactory
    {
        public static User Create(AppUser appUser)
        {
            if (appUser == null)
                return null;

            var user = new User
            {
                Id = appUser.Id,
                Email = appUser.Email,
                UserName = appUser.UserName,
                EmailConfirmed = appUser.EmailConfirmed,
                AccessFailedCount = appUser.AccessFailedCount,
                LockoutEnabled = appUser.LockoutEnabled,
                LockoutEndDateUtc = appUser.LockoutEndDateUtc,
                PasswordHash = appUser.PasswordHash,
                PhoneNumber = appUser.PhoneNumber,
                PhoneNumberConfirmed = appUser.PhoneNumberConfirmed,
                SecurityStamp = appUser.SecurityStamp,
                TwoFactorEnabled = appUser.TwoFactorEnabled
            };
            foreach (var role in appUser.Roles)
                user.Roles.Add(Create(role));
            foreach (var login in appUser.Logins)
                user.Logins.Add(Create(login));
            foreach (var claim in appUser.Claims)
                user.Claims.Add(Create(claim));

            return user;
        }

        public static AppUser Create(User user)
        {
            if (user == null)
                return null;

            var appUser = new AppUser
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed,
                AccessFailedCount = user.AccessFailedCount,
                LockoutEnabled = user.LockoutEnabled,
                LockoutEndDateUtc = user.LockoutEndDateUtc,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                SecurityStamp = user.SecurityStamp,
                TwoFactorEnabled = user.TwoFactorEnabled
            };
            foreach (var role in user.Roles)
                appUser.Roles.Add(Create(role));
            foreach (var login in user.Logins)
                appUser.Logins.Add(Create(login));
            foreach (var claim in user.Claims)
                appUser.Claims.Add(Create(claim));

            return appUser;
        }

        public static Role Create(AppRole appRole)
        {
            if (appRole == null)
                return null;

            var role = new Role
            {
                Id = appRole.Id,
                Name = appRole.Name
            };
            foreach (var userRole in appRole.Users)
                role.Users.Add(Create(userRole));

            return role;
        }

        public static AppRole Create(Role role)
        {
            if (role == null)
                return null;

            var appRole = new AppRole
            {
                Id = role.Id,
                Name = role.Name
            };
            foreach (var userRole in role.Users)
                appRole.Users.Add(Create(userRole));

            return appRole;
        }

        public static UserRole Create(AppUserRole appUserRole)
        {
            if (appUserRole == null)
                return null;

            var userRole = new UserRole
            {
                UserId = appUserRole.UserId,
                RoleId = appUserRole.RoleId
            };

            return userRole;
        }

        public static AppUserRole Create(UserRole userRole)
        {
            if (userRole == null)
                return null;

            var appUserRole = new AppUserRole
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            };

            return appUserRole;
        }

        public static UserLogin Create(AppUserLogin appUserLogin)
        {
            if (appUserLogin == null)
                return null;

            var userLogin = new UserLogin
            {
                LoginProvider = appUserLogin.LoginProvider,
                ProviderKey = appUserLogin.ProviderKey,
                UserId = appUserLogin.UserId
            };

            return userLogin;
        }

        public static AppUserLogin Create(UserLogin userLogin)
        {
            if (userLogin == null)
                return null;

            var appUserLogin = new AppUserLogin
            {
                LoginProvider = userLogin.LoginProvider,
                ProviderKey = userLogin.ProviderKey,
                UserId = userLogin.UserId
            };

            return appUserLogin;
        }

        public static UserClaim Create(AppUserClaim appUserClaim)
        {
            if (appUserClaim == null)
                return null;

            var userClaim = new UserClaim
            {
                Id = appUserClaim.Id,
                UserId = appUserClaim.UserId,
                ClaimType = appUserClaim.ClaimType,
                ClaimValue = appUserClaim.ClaimValue
            };

            return userClaim;
        }

        public static AppUserClaim Create(UserClaim userClaim)
        {
            if (userClaim == null)
                return null;

            var appUserClaim = new AppUserClaim
            {
                Id = userClaim.Id,
                UserId = userClaim.UserId,
                ClaimType = userClaim.ClaimType,
                ClaimValue = userClaim.ClaimValue
            };

            return appUserClaim;
        }

        public static UserLoginInfo Create(Microsoft.AspNet.Identity.UserLoginInfo identityUserLoginInfo)
        {
            if (identityUserLoginInfo == null)
                return null;

            var coreUserLoginInfo = new UserLoginInfo(
                identityUserLoginInfo.LoginProvider, identityUserLoginInfo.ProviderKey);

            return coreUserLoginInfo;
        }

        public static Microsoft.AspNet.Identity.UserLoginInfo Create(UserLoginInfo coreUserLoginInfo)
        {
            if (coreUserLoginInfo == null)
                return null;

            var identityUserLoginInfo = new Microsoft.AspNet.Identity.UserLoginInfo(
                coreUserLoginInfo.LoginProvider, coreUserLoginInfo.ProviderKey);

            return identityUserLoginInfo;
        }

        public static AuthenticationDescription Create(Microsoft.Owin.Security.AuthenticationDescription identityAuthDescrip)
        {
            if (identityAuthDescrip == null)
                return null;

            var authenticationDescription = new AuthenticationDescription
            {
                AuthenticationType = identityAuthDescrip.AuthenticationType,
                Caption = identityAuthDescrip.Caption,
            };
            foreach (var property in identityAuthDescrip.Properties)
                authenticationDescription.Properties.Add(property.Key, property.Value);

            return authenticationDescription;
        }

        public static Microsoft.Owin.Security.AuthenticationDescription Create(AuthenticationDescription authDescrip)
        {
            if (authDescrip == null)
                return null;

            var identityAuthDescription = new Microsoft.Owin.Security.AuthenticationDescription
            {
                AuthenticationType = authDescrip.AuthenticationType,
                Caption = authDescrip.Caption,
            };
            foreach (var property in authDescrip.Properties)
                identityAuthDescription.Properties.Add(property.Key, property.Value);

            return identityAuthDescription;
        }

        public static ExternalLoginInfo Create(Microsoft.AspNet.Identity.Owin.ExternalLoginInfo identityExternalLoginInfo)
        {
            if (identityExternalLoginInfo == null)
                return null;

            var externalLoginInfo = new ExternalLoginInfo
            {
                DefaultUserName = identityExternalLoginInfo.DefaultUserName,
                Email = identityExternalLoginInfo.Email,
                ExternalIdentity = identityExternalLoginInfo.ExternalIdentity,
                Login = Create(identityExternalLoginInfo.Login)
            };

            return externalLoginInfo;
        }

        public static AuthResult Create(IdentityResult identityResult)
        {
            if (identityResult == null)
                return null;

            var authResult = new AuthResult(
                identityResult.Errors, identityResult.Succeeded);

            return authResult;
        }
    }
}
