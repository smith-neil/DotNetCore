using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DotNetCore.Core.Security.Models;
using DotNetCore.Core.Utilities;
using DotNetCore.Data.EntityFramework.Identity.Utilities;
using Microsoft.Owin.Security;
using AuthenticationDescription = DotNetCore.Core.Security.Models.AuthenticationDescription;
using IAuthenticationManager = DotNetCore.Core.Security.IAuthenticationManager;

namespace DotNetCore.Data.EntityFramework.Identity
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly Microsoft.Owin.Security.IAuthenticationManager _authenticationManager;

        public AuthenticationManager(Microsoft.Owin.Security.IAuthenticationManager authenticationManager)
        {
            authenticationManager.ThrowIfNull("authenticationManager");

            _authenticationManager = authenticationManager;
        }

        public IEnumerable<AuthenticationDescription> GetExternalAuthenticationTypes()
        {
            var identityAuthDescriptions = _authenticationManager.GetExternalAuthenticationTypes();
            var authDescriptions = identityAuthDescriptions.Select(IdentityModelFactory.Create);

            return authDescriptions;
        }

        public ExternalLoginInfo GetExternalLoginInfo()
        {
            var externalLoginInfo = _authenticationManager.GetExternalLoginInfo();
            var appExternalLoginInfos = IdentityModelFactory.Create(externalLoginInfo);

            return appExternalLoginInfos;
        }

        public async Task<ExternalLoginInfo> GetExternalLoginInfoAsync()
        {
            var externalLoginInfo = await _authenticationManager.GetExternalLoginInfoAsync();
            var appExternalLoginInfos = IdentityModelFactory.Create(externalLoginInfo);

            return appExternalLoginInfos;
        }

        public void SignIn(params ClaimsIdentity[] identities)
        {
            identities.ThrowIfNull("identities");

            _authenticationManager.SignIn(identities);
        }

        public void SignOut(params string[] authenticationTypes)
        {
            authenticationTypes.ThrowIfNull("authenticationTypes");

            _authenticationManager.SignOut(authenticationTypes);
        }
    }
}
