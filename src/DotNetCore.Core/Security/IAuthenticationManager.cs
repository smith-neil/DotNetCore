using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DotNetCore.Core.Security.Models;

namespace DotNetCore.Core.Security
{
    public interface IAuthenticationManager
    {
        IEnumerable<AuthenticationDescription> GetExternalAuthenticationTypes();

        ExternalLoginInfo GetExternalLoginInfo();
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();

        void SignIn(params ClaimsIdentity[] identities);

        void SignOut(params string[] authenticationTypes);
    }
}
