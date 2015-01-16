using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.Core.Security;
using DotNetCore.Core.Security.Models;
using DotNetCore.Core.Utilities;
using DotNetCore.Data.EntityFramework.Identity.Models;
using DotNetCore.Data.EntityFramework.Identity.Utilities;
using Microsoft.AspNet.Identity;

namespace DotNetCore.Data.EntityFramework.Identity
{
    public class RoleManager : IRoleManager
    {
        private readonly Microsoft.AspNet.Identity.RoleManager<AppRole, int> _roleManager;
        private bool _disposed;

        public RoleManager(RoleManager<AppRole, int> roleManager) {
            roleManager.ThrowIfNull("roleManager");

            _roleManager = roleManager;
        }

        public AuthResult Create(Role role) {
            role.ThrowIfNull("role");

            var identityRole = IdentityModelFactory.Create(role);
            var identityResult = _roleManager.Create(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create succeedes, copy properties from the new IdentityRole to the 
            // passed in AppRole
            if (appIdentityResult.Succeeded)
                role.CopyFrom(identityRole);

            return appIdentityResult;
        }

        public async Task<AuthResult> CreateAsync(Role role)
        {
            role.ThrowIfNull("role");

            var identityRole = IdentityModelFactory.Create(role);
            var identityResult = await _roleManager.CreateAsync(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            // if create succeedes, copy properties from the new IdentityRole to the 
            // passed in AppRole
            if (appIdentityResult.Succeeded)
                role.CopyFrom(identityRole);

            return appIdentityResult;
        }

        public AuthResult Delete(int roleId) {
            var identityRole = _roleManager.FindById(roleId);

            if (identityRole == null)
                return CreateErrorResult(new[] {"Invalid roleId"});

            var identityResult = _roleManager.Delete(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AuthResult> DeleteAsync(int roleId)
        {
            var identityRole = await _roleManager.FindByIdAsync(roleId);

            if (identityRole == null)
                return CreateErrorResult(new[] { "Invalid roleId" });

            var identityResult = await _roleManager.DeleteAsync(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public Role FindById(int roleId) {
            var identityRole = _roleManager.FindById(roleId);
            var appRole = IdentityModelFactory.Create(identityRole);

            return appRole;
        }

        public async Task<Role> FindByIdAsync(int roleId) {
            var identityRole = await _roleManager.FindByIdAsync(roleId);
            var appRole = IdentityModelFactory.Create(identityRole);

            return appRole;
        }

        public Role FindByName(string roleName) {
            roleName.ThrowIfNull("roleName");

            var identityRole = _roleManager.FindByName(roleName);
            var appRole = IdentityModelFactory.Create(identityRole);

            return appRole;
        }

        public async Task<Role> FindByNameAsync(string roleName) {
            roleName.ThrowIfNull("roleName");

            var identityRole = await _roleManager.FindByNameAsync(roleName);
            var appRole = IdentityModelFactory.Create(identityRole);

            return appRole;
        }

        public IEnumerable<Role> GetRoles() {
            var identityRoles = _roleManager.Roles.ToList();
            var appRoles = identityRoles.Select(IdentityModelFactory.Create);

            return appRoles;
        }

        public async Task<IEnumerable<Role>> GetRolesAsync() {
            var identityRoles = await _roleManager.Roles.ToListAsync();
            var appRoles = identityRoles.Select(IdentityModelFactory.Create);

            return appRoles;
        }

        public bool RoleExists(string roleName) {
            roleName.ThrowIfNull("roleName");

            return _roleManager.RoleExists(roleName);
        }

        public async Task<bool> RoleExistsAsync(string roleName) {
            roleName.ThrowIfNull("roleName");

            return await _roleManager.RoleExistsAsync(roleName);
        }

        public AuthResult Update(int roleId, string roleName)
        {
            roleName.ThrowIfNull("roleName");

            var identityRole = _roleManager.FindById(roleId);
            if (identityRole == null)
                return CreateErrorResult(new[] {"Invalid roleId."});

            identityRole.Name = roleName;
            var identityResult = _roleManager.Update(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        public async Task<AuthResult> UpdateAsync(int roleId, string roleName)
        {
            roleName.ThrowIfNull("roleName");

            var identityRole = await _roleManager.FindByIdAsync(roleId);
            if (identityRole == null)
                return CreateErrorResult(new[] { "Invalid roleId." });

            identityRole.Name = roleName;
            var identityResult = await _roleManager.UpdateAsync(identityRole);
            var appIdentityResult = IdentityModelFactory.Create(identityResult);

            return appIdentityResult;
        }

        private AuthResult CreateErrorResult(IEnumerable<string> errors)
        {
            return new AuthResult(errors, false);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing) {
            if (!_disposed && disposing) {
                if (_roleManager != null) {
                    _roleManager.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
