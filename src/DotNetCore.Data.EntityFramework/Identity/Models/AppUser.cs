using Microsoft.AspNet.Identity.EntityFramework;

namespace DotNetCore.Data.EntityFramework.Identity.Models
{
    public class AppUser : IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>
    {
    }
}
