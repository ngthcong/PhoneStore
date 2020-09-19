using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using PhoneStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.CustomHandler
{
    public class RoleAuthorizationHandler: AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        private readonly PhoneStoreDBContext _context;

        public RoleAuthorizationHandler(PhoneStoreDBContext context)
        {
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            var validRole = false;
            if (requirement.AllowedRoles == null || requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
                var claims = context.User.Claims;
                var userEmail= claims.FirstOrDefault(c => c.Type == "UserEmail").Value;
                var roles = requirement.AllowedRoles;
                validRole = _context.Account.Where(p => roles.Contains(p.AccRoleId.ToString()) && p.AccEmail == userEmail).Any();

            }
            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
