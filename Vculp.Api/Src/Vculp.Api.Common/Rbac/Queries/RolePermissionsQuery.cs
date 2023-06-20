using System;
using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.Rbac.Queries
{
    public class RolePermissionsQuery : PagedResourceParameters, IRequest<IPagedList<RolePermissionResponse>>
    {
        public RolePermissionsQuery()
          : base(10, 20)
        {
        }

        public Guid RoleId { get; set; }
    }
}
