using System.Collections.Generic;

namespace DotNetCore.Core.Security.Models
{
    public class Role
    {
        public Role() 
        {
            Users = new List<UserRole>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<UserRole> Users { get; private set; }
    }
}
