namespace DotNetCore.Core.Security.Models
{
    public class UserRole
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int UserId { get; set; }
        public Role User { get; set; }
    }
}
