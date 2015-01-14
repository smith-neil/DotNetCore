using System.Security.Claims;
using System.Threading.Tasks;
using DotNetCore.Core.Security.Models;

namespace DotNetCore.Core.Security
{
    public interface IUserManager
    {
        string Cookie { get; }
        string ExternalBearer { get; }
        string ExternalCookie { get; }
        string TwoFactorCookie { get; }
        string TwoFactorRememberBrowserCookie { get; }

        AuthResult AddLogin(int userId, UserLoginInfo loginInfo);
        Task<AuthResult> AddLoginAsync(int userId, UserLoginInfo loginInfo);

        AuthResult AddPassword(int userId, string password);
        Task<AuthResult> AddPasswordAsync(int userId, string password);

        AuthResult AddToRole(int userId, string roleName);
        Task<AuthResult> AddToRoleAsync(int userId, string roleName);

        AuthResult ChangePassword(int userId, string oldPassword, string newPassword);
        Task<AuthResult> ChangePasswordAsync(int userId, string oldPassword, string newPassword);

        AuthResult Create(User user);
        Task<AuthResult> CreateAsync(User user);

        AuthResult Create(User user, string password);
        Task<AuthResult> CreateAsync(User user, string password);

        ClaimsIdentity CreateIdentity(User user, string authenticationType);
        Task<ClaimsIdentity> CreateIdentityAsync(User user, string authenticationType);

        User FindByUserNameAndPassword(string userName, string password);
        Task<User> FindByUserNameAndPasswordAsync(string userName, string password);

        User FindByEmail(string email);
        Task<User> FindByEmailAsync(string email);

        User FindByUserLoginInfo(UserLoginInfo loginInfo);
        Task<User> FindByUserLoginInfoAsync(UserLoginInfo loginInfo);

        User FindById(int userId);
        Task<User> FindByIdAsync(int userId);

        User FindByUserName(string userName);
        Task<User> FindByUserNameAsync(string userName);

        AuthResult RemoveLogin(int userId, UserLoginInfo loginInfo);
        Task<AuthResult> RemoveLoginAsync(int userId, UserLoginInfo loginInfo);
    }
}
