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
    public class RolesQueryHandler : QueryHandler, IRequestHandler<RolesQuery, IPagedList<RoleResponse>>
    {
        public RolesQueryHandler(CoreContext context)
          : base(context)
        {
        }

        public async Task<IPagedList<RoleResponse>> Handle(RolesQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = (int)request.PageNumber;
            var pageSize = (int)request.PageSize;


            var count = await Context.Roles
                                     .CountAsync(cancellationToken);

            var roles = await Context.Roles
                                     .OrderBy(d => d.Name)
                                     .Select(t => RoleMapper.MapTo<RoleResponse>(t))
                                     .PageResults(pageNumber, pageSize)
                                     .ToListAsync(cancellationToken);

            return roles.ToPagedList(count, pageNumber, pageSize);

        }
    }
}
