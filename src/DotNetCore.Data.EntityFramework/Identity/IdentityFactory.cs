using System;
using System.Data.Entity;
using DotNetCore.Data.EntityFramework.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DotNetCore.Data.EntityFramework.Identity
{
    public class IdentityFactory
    {
        public static UserManager<AppUser, int> CreateUserManager(DbContext context)
        {
            var manager = new UserManager<AppUser, int>(
                new UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>(context));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AppUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = false;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<AppUser, int>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<AppUser, int>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });

            // TODO
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();

            return manager;
        }

        public static RoleManager<AppRole, int> CreateRoleManager(DbContext context)
        {
            return new RoleManager<AppRole, int>(new RoleStore<AppRole, int, AppUserRole>(context));
        }
    }
}
