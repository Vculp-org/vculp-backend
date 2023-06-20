using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.Rbac.Queries
{
    public class UsersQuery : PagedResourceParameters, IRequest<IPagedList<UserResponse>>
    {
        public UsersQuery()
          : base(10, 20)
        {
        }

        public string Search { get; set; }
    }
}
