using Microsoft.AspNet.Identity.EntityFramework;

namespace DotNetCore.Data.EntityFramework.Identity.Models
{
    public class AppRole<T> : IdentityRole<T, AppUserRole<T>>
    {
    }
}
