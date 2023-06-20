using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.Rbac.Queries
{
    public class RolesQuery : PagedResourceParameters, IRequest<IPagedList<RoleResponse>>
    {
        public RolesQuery()
         : base(10, 20)
        {
        }
    }
}
