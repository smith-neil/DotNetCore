namespace DotNetCore.Core.Security.Models
{
    public class UserLoginInfo
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public UserLoginInfo(string loginProvider, string providerKey) 
        {
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
        }
    }
}
