using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Queries;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Data.EntityFramework.Extensions;
using Vculp.Api.Shared;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Data.EntityFramework.Rbac.QueryHandlers
{
    public class AuthenticatedUserApplicationPermissionsQueryHandler : QueryHandler, IRequestHandler<AuthenticatedUserApplicationPermissionsQuery, IPagedList<ApplicationPermissionResponse>>
    {
        private readonly ICurrentUserAccessor _currentUserAccessor;

        public AuthenticatedUserApplicationPermissionsQueryHandler(ICurrentUserAccessor currentUserAccessor, CoreContext context)
         : base(context)
        {
            _currentUserAccessor = currentUserAccessor ?? throw new ArgumentNullException(nameof(currentUserAccessor));
        }

        public async Task<IPagedList<ApplicationPermissionResponse>> Handle(AuthenticatedUserApplicationPermissionsQuery request, CancellationToken cancellationToken)
        {

            var pageNumber = (int)request.PageNumber;
            var pageSize = (int)request.PageSize;            

            var userRoles = Context.Roles
                                    .Join(Context.RoleMembers, role => role.Id, roleMember => roleMember.RoleId, (role, roleMember) => new { role, roleMember })
                                    .Join(Context.Users, roleMember => roleMember.roleMember.UserId, user => user.Id, (roleMember, user) => new { roleMember.role, user })
                                    .Where(user => user.user.ExternalUserId == _currentUserAccessor.UserId);

            var permissions = Context.RolePermissions.Join(userRoles, rolePermission => rolePermission.RoleId, userRole => userRole.role.Id, (permission, role) => permission.ApplicationPermissionId).Distinct();



            var permissionDetails = Context.ApplicationPermissions.Join(permissions, ap => ap.Id, p => p, (ap, p) => ap);

            if (!string.IsNullOrWhiteSpace(request.Key))
            {
                permissionDetails = permissionDetails.Where(p => p.PermissionKey == request.Key);
            }

            var count = await permissionDetails.CountAsync();

            var pagedResults = await permissionDetails.OrderBy(ap => ap.DisplayName)
                                               .PageResults(pageNumber, pageSize)
                                               .Select(ap => new
                                               {
                                                   ApplicationPermissionId = ap.Id,
                                                   DisplayName = ap.DisplayName,
                                                   PermissionKey = ap.PermissionKey,
                                                   Description = ap.Description
                                               }).ToListAsync();

            return pagedResults.Select(r => new ApplicationPermissionResponse
            {
                ApplicationPermissionId = r.ApplicationPermissionId,
                DisplayName = r.DisplayName,
                PermissionKey = r.PermissionKey,
                Description = r.Description
            }).ToPagedList(count, pageNumber, pageSize);
        }
    }
}
