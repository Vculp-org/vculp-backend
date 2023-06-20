using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Rbac;
using Vculp.Api.Domain.Interfaces.Rbac.Repositories;

namespace Vculp.Api.Data.EntityFramework.Rbac.Repositories
{
    public class ApplicationPermissionRepository : Repository<ApplicationPermission>, IApplicationPermissionRepository
    {
        public ApplicationPermissionRepository(CoreContext context)
            : base(context)
        {
        }

        protected override IQueryable<ApplicationPermission> IncludeAll()
        {
            return DbSet;
        }

        public async Task<IEnumerable<ApplicationPermission>> GetForExternalUserId(int externalUserId)
        {
            var userRoles = Context.Roles
                .Join(Context.RoleMembers, role => role.Id, roleMember => roleMember.RoleId,
                    (role, roleMember) => new { role, roleMember })
                .Join(Context.Users, roleMember => roleMember.roleMember.UserId, user => user.Id,
                    (roleMember, user) => new { roleMember.role, user })
                .Where(user => user.user.ExternalUserId == externalUserId);

            var permissions = Context.RolePermissions
                .Join(userRoles, rolePermission => rolePermission.RoleId, userRole => userRole.role.Id,
                    (permission, role) => permission.ApplicationPermissionId)
                .Distinct();

            var permissionDetails =
                await IncludeAll()
                    .Join(permissions, ap => ap.Id, p => p, (ap, p) => ap)
                    .ToListAsync();

            return permissionDetails;
        }
    }
}
