using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCore.Core.Security.Models;

namespace DotNetCore.Core.Security
{
    public interface IRoleManager
    {
        AuthResult Create(Role role);
        Task<AuthResult> CreateAsync(Role role);

        AuthResult Delete(int roleId);
        Task<AuthResult> DeleteAsync(int roleId);

        Role FindById(int roleId);
        Task<Role> FindByIdAsync(int roleId);

        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);

        IEnumerable<Role> GetRoles();
        Task<IEnumerable<Role>> GetRolesAsync();

        bool RoleExists(string roleName);
        Task<bool> RoleExistsAsync(string roleName);

        AuthResult Update(int roleId, string roleName);
        Task<AuthResult> UpdateAsync(int roleId, string roleName);
    }
}
