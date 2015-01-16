using Microsoft.AspNet.Identity.EntityFramework;

namespace DotNetCore.Data.EntityFramework.Identity.Models
{
    public class AppUser<T> : IdentityUser<T, AppUserLogin<T>, AppUserRole<T>, AppUserClaim<T>>
    {
    }
}
