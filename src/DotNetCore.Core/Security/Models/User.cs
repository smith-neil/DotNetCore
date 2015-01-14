using System;
using System.Collections.Generic;

namespace DotNetCore.Core.Security.Models
{
    public class User
    {
        public User() 
        {
            Claims = new List<UserClaim>();
            Roles = new List<UserRole>();
            Logins = new List<UserLogin>();
        }

        public int AccessFailedCount { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public int Id { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }

        public ICollection<UserRole> Roles { get; private set; }
        public ICollection<UserLogin> Logins { get; private set; }
        public ICollection<UserClaim> Claims { get; private set; }
    }
}
