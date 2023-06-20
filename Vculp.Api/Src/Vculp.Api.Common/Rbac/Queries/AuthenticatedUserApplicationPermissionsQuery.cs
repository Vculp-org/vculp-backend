using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.Rbac.Queries
{
    public class AuthenticatedUserApplicationPermissionsQuery : PagedResourceParameters, IRequest<IPagedList<ApplicationPermissionResponse>>
    {
        public AuthenticatedUserApplicationPermissionsQuery()
            : base(10, int.MaxValue)
        {
        }

        public string Key { get; set; }
    }
}
