namespace DotNetCore.Core.Security.Models
{
    public class UserClaim
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
