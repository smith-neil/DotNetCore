using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DotNetCore.Core.Security;
using DotNetCore.Core.Security.Models;
using DotNetCore.Core.Utilities;
using DotNetCore.Data.EntityFramework.Identity.Models;
using DotNetCore.Data.EntityFramework.Identity.Utilities;
using Microsoft.AspNet.Identity;
using UserLoginInfo = DotNetCore.Core.Security.Models.UserLoginInfo;

namespace DotNetCore.Data.EntityFramework.Identity
{
    public class UserManager : IUserManager
    {
        private readonly Microsoft.AspNet.Identity.UserManager<AppUser, int> _userManager;
        private bool _disposed;

        public UserManager(UserManager<AppUser, int> userManager)
        {
            userManager.ThrowIfNull("userManager");

            _userManager = userManager;
        }

        public string AppCookie
        {
            get { return DefaultAuthenticationTypes.ApplicationCookie; }
        }

        public string Cookie
        {
            get { return DefaultAuthenticationTypes.ApplicationCookie; }
        }

        public string ExternalBearer
        {
            get { return DefaultAuthenticationTypes.ExternalBearer; }
        }

        public string ExternalCookie
        {
            get { return DefaultAuthenticationTypes.ExternalCookie; }
        }

        public string TwoFactorCookie
        {
            get { return DefaultAuthenticationTypes.TwoFactorCookie; }
        }

        public string TwoFactorRememberBrowserCookie
        {
            get { return DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie; }
        }

        public AuthResult AddLogin(int userId, UserLoginInfo loginInfo)
        {
            loginInfo.ThrowIfNull("loginInfo");

            var identityUserLoginInfo = IdentityModelFactory.Create(loginInfo);
            var identityResult = _userManager.AddLogin(userId, identityUserLoginInfo);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AuthResult> AddLoginAsync(int userId, UserLoginInfo loginInfo)
        {
            loginInfo.ThrowIfNull("loginInfo");

            var identityUserLoginInfo = IdentityModelFactory.Create(loginInfo);
            var identityResult = await _userManager.AddLoginAsync(userId, identityUserLoginInfo);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public AuthResult AddPassword(int userId, string password)
        {
            password.ThrowIfNull("password");

            var identityResult = _userManager.AddPassword(userId, password);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AuthResult> AddPasswordAsync(int userId, string password)
        {
            password.ThrowIfNull("password");

            var identityResult = await _userManager.AddPasswordAsync(userId, password);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public AuthResult AddToRole(int userId, string roleName)
        {
            roleName.ThrowIfNull("roleName");

            var identityResult = _userManager.AddToRole(userId, roleName);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AuthResult> AddToRoleAsync(int userId, string roleName)
        {
            roleName.ThrowIfNull("roleName");

            var identityResult = await _userManager.AddToRoleAsync(userId, roleName);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public AuthResult ChangePassword(int userId, string oldPassword, string newPassword)
        {
            oldPassword.ThrowIfNull("oldPassword");
            newPassword.ThrowIfNull("newPassword");

            var identityResult = _userManager.ChangePassword(userId, oldPassword, newPassword);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AuthResult> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            oldPassword.ThrowIfNull("oldPassword");
            newPassword.ThrowIfNull("newPassword");

            var identityResult = await _userManager.ChangePasswordAsync(userId, oldPassword, newPassword);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public AuthResult Create(User user)
        {
            user.ThrowIfNull("user");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var identityResult = _userManager.Create(appIdentityUser);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create is successful, copy the AppIdentityUser's properties
            // back to the AppUser that was passed in
            if (appIdentityResult.Succeeded)
                user.CopyFrom(appIdentityUser);

            return appIdentityResult;
        }

        public async Task<AuthResult> CreateAsync(User user)
        {
            user.ThrowIfNull("user");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var identityResult = await _userManager.CreateAsync(appIdentityUser);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create is successful, copy the AppIdentityUser's properties
            // back to the AppUser that was passed in
            if (appIdentityResult.Succeeded)
                user.CopyFrom(appIdentityUser);

            return appIdentityResult;
        }

        public AuthResult Create(User user, string password)
        {
            user.ThrowIfNull("user");
            password.ThrowIfNull("password");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var identityResult = _userManager.Create(appIdentityUser, password);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create is successful, copy the AppIdentityUser's properties
            // back to the AppUser that was passed in
            if (appIdentityResult.Succeeded)
                user.CopyFrom(appIdentityUser);

            return appIdentityResult;
        }

        public async Task<AuthResult> CreateAsync(User user, string password)
        {
            user.ThrowIfNull("user");
            password.ThrowIfNull("password");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var identityResult = await _userManager.CreateAsync(appIdentityUser, password);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create is successful, copy the AppIdentityUser's properties
            // back to the AppUser that was passed in
            if (appIdentityResult.Succeeded)
                user.CopyFrom(appIdentityUser);

            return appIdentityResult;
        }

        public ClaimsIdentity CreateIdentity(User user, string authenticationType)
        {
            user.ThrowIfNull("user");
            authenticationType.ThrowIfNull("authenticationType");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var claimsIdentity = _userManager.CreateIdentity(appIdentityUser, authenticationType);

            user.CopyFrom(appIdentityUser);

            return claimsIdentity;
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType)
        {
            user.ThrowIfNull("user");
            authenticationType.ThrowIfNull("authenticationType");

            var appIdentityUser = IdentityModelFactory.Create(user);
            var claimsIdentity = await _userManager.CreateIdentityAsync(appIdentityUser, authenticationType);

            user.CopyFrom(appIdentityUser);

            return claimsIdentity;
        }

        public User FindByUserNameAndPassword(string userName, string password)
        {
            userName.ThrowIfNull("userName");
            password.ThrowIfNull("password");

            var identityUser = _userManager.Find(userName, password);
            var user = IdentityModelFactory.Create(identityUser);

            return user;
        }

        public async Task<User> FindByUserNameAndPasswordAsync(string userName, string password)
        {
            userName.ThrowIfNull("userName");
            password.ThrowIfNull("password");

            var identityUser = await _userManager.FindAsync(userName, password);
            var user = IdentityModelFactory.Create(identityUser);

            return user;
        }

        public User FindByEmail(string email)
        {
            email.ThrowIfNull("email");

            var appIdentityUser = _userManager.FindByEmail(email);
            var user = IdentityModelFactory.Create(appIdentityUser);

            return user;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            email.ThrowIfNull("email");

            var appIdentityUser = await _userManager.FindByEmailAsync(email);
            var user = IdentityModelFactory.Create(appIdentityUser);

            return user;
        }

        public User FindByUserLoginInfo(UserLoginInfo loginInfo)
        {
            loginInfo.ThrowIfNull("loginInfo");

            var userLoginInfo = IdentityModelFactory.Create(loginInfo);
            var appIdentityUser = _userManager.Find(userLoginInfo);
            var user = IdentityModelFactory.Create(appIdentityUser);

            return user;
        }

        public async Task<User> FindByUserLoginInfoAsync(UserLoginInfo loginInfo)
        {
            loginInfo.ThrowIfNull("loginInfo");

            var userLoginInfo = IdentityModelFactory.Create(loginInfo);
            var appIdentityUser = await _userManager.FindAsync(userLoginInfo);
            var user = IdentityModelFactory.Create(appIdentityUser);

            return user;
        }

        public User FindById(int userId)
        {
            var appIdentityUser = _userManager.FindById(userId);
            var user = IdentityModelFactory.Create(appIdentityUser);

            return user;
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            var appIdentityUser = await _userManager.FindByIdAsync(userId);
            var user = IdentityModelFactory.Create(appIdentityUser);

            return user;
        }

        public User FindByUserName(string userName)
        {
            userName.ThrowIfNull("userName");

            var appIdentityUser = _userManager.FindByName(userName);
            var user = IdentityModelFactory.Create(appIdentityUser);

            return user;
        }

        public async Task<User> FindByUserNameAsync(string userName)
        {
            userName.ThrowIfNull("userName");

            var appIdentityUser = await _userManager.FindByNameAsync(userName);
            var user = IdentityModelFactory.Create(appIdentityUser);

            return user;
        }

        public AuthResult RemoveLogin(int userId, UserLoginInfo loginInfo)
        {
            loginInfo.ThrowIfNull("loginInfo");

            var userLoginInfo = IdentityModelFactory.Create(loginInfo);
            var identityResult = _userManager.RemoveLogin(userId, userLoginInfo);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AuthResult> RemoveLoginAsync(int userId, UserLoginInfo loginInfo)
        {
            loginInfo.ThrowIfNull("loginInfo");

            var userLoginInfo = IdentityModelFactory.Create(loginInfo);
            var identityResult = await _userManager.RemoveLoginAsync(userId, userLoginInfo);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
