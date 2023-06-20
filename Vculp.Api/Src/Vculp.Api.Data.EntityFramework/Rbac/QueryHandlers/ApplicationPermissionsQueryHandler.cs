using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Common.Rbac.Mappers;
using Vculp.Api.Common.Rbac.Queries;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Data.EntityFramework.Extensions;
using Vculp.Api.Shared;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Data.EntityFramework.Rbac.QueryHandlers
{
    public class ApplicationPermissionsQueryHandler : QueryHandler, IRequestHandler<ApplicationPermissionsQuery, IPagedList<ApplicationPermissionResponse>>
    {
        public ApplicationPermissionsQueryHandler(CoreContext context)
            : base(context)
        {
        }

        public async Task<IPagedList<ApplicationPermissionResponse>> Handle(ApplicationPermissionsQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = (int)request.PageNumber;
            var pageSize = (int)request.PageSize;


            var count = await Context.ApplicationPermissions
                                     .CountAsync(cancellationToken);

            var applicationPermissions = await Context.ApplicationPermissions
                                         .OrderBy(d => d.DisplayName)
                                         .Select(t => ApplicationPermissionMapper.MapTo<ApplicationPermissionResponse>(t))
                                         .PageResults(pageNumber, pageSize)
                                         .ToListAsync(cancellationToken);

            return applicationPermissions.ToPagedList(count, pageNumber, pageSize);

        }
    }
}
