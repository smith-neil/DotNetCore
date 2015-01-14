using System.Security.Claims;

namespace DotNetCore.Core.Security.Models
{
    public class ExternalLoginInfo
    {
        public string DefaultUserName { get; set; }

        public string Email { get; set; }

        public ClaimsIdentity ExternalIdentity { get; set; }

        public UserLoginInfo Login { get; set; }
    }
}
