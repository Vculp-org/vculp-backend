using System;
using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.Rbac.Queries
{
    public class RoleMembersQuery : PagedResourceParameters, IRequest<IPagedList<RoleMemberResponse>>
    {
        public RoleMembersQuery()
           : base(10, 20)
        {
        }

        public Guid RoleId { get; set; }
    }
}
