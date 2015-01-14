namespace DotNetCore.Core.Security.Models
{
    public class UserRole
    {
        public virtual int RoleId { get; set; }
        public virtual int UserId { get; set; }
    }
}
