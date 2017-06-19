using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interface;

namespace MvcPL.Providers
{
    public class CustomRoleProvider: RoleProvider
    {
        public IUserService UserService => (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
        public IRoleService RoleService => (IRoleService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IRoleService));
        public override bool IsUserInRole(string email, string roleName)
        {
            var roleId = UserService.GetUserByEmail(email).RoleId;
            if (!roleId.HasValue) return false;
            var userRoleName = RoleService.GetRoleNameById(roleId.Value);
            if (userRoleName.Equals(roleName)) return true;
            return false;
        }

        public override string[] GetRolesForUser(string email)
        {
            var roleId = UserService.GetUserByEmail(email).RoleId;
            return !roleId.HasValue ? new string[] { } : new string[] { RoleService.GetRoleNameById(roleId.Value)};
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}