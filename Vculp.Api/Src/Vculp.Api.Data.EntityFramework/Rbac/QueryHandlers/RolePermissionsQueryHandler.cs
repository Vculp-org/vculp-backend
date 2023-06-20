using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Common.Rbac.Queries;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Data.EntityFramework.Extensions;
using Vculp.Api.Shared;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Data.EntityFramework.Rbac.QueryHandlers
{
    public class RolePermissionsQueryHandler : QueryHandler, IRequestHandler<RolePermissionsQuery, IPagedList<RolePermissionResponse>>
    {
        public RolePermissionsQueryHandler(CoreContext context)
         : base(context)
        {
        }

        public async Task<IPagedList<RolePermissionResponse>> Handle(RolePermissionsQuery request, CancellationToken cancellationToken)
        {

            var role = await Context.Roles.SingleOrDefaultAsync(r => r.Id == request.RoleId);

            if (role == null)
            {
                return null;
            }

            var pageNumber = (int)request.PageNumber;
            var pageSize = (int)request.PageSize;

            var rolePermissions = Context.RolePermissions.Where(r => r.RoleId == request.RoleId).Join(Context.ApplicationPermissions,
                                    r => r.ApplicationPermissionId,
                                    p => p.Id,
                                    (r, p) => new
                                    {
                                        ApplicationPermission = p,
                                        RolePermission = r
                                    });

            var count = await rolePermissions.CountAsync();
            var pagedResults = await rolePermissions.OrderBy(s => s.ApplicationPermission.DisplayName)
                                                    .PageResults(pageNumber, pageSize)
                                                    .Select(p => new
                                                    {
                                                        Id = p.RolePermission.Id,
                                                        RoleId = request.RoleId,
                                                        Name = p.ApplicationPermission.DisplayName,
                                                        ApplicationPermissionId = p.ApplicationPermission.Id,
                                                        PermissionKey = p.ApplicationPermission.PermissionKey,
                                                        DisplayName = p.ApplicationPermission.DisplayName,
                                                        Description = p.ApplicationPermission.Description                                                    
                                                    }).ToListAsync();


            return pagedResults.Select(p => new RolePermissionResponse
            {
                Id = p.Id,
                RoleId = p.RoleId,
                Name = p.Name,
                ApplicationPermissionId = p.ApplicationPermissionId,
                PermissionKey = p.PermissionKey,
                DisplayName = p.DisplayName,
                Description = p.Description
            }).ToPagedList(count, pageNumber, pageSize);
        }
    }
}
