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
    public class RoleMembersQueryHandler : QueryHandler, IRequestHandler<RoleMembersQuery, IPagedList<RoleMemberResponse>>
    {
        public RoleMembersQueryHandler(CoreContext context)
          : base(context)
        {
        }

        public async Task<IPagedList<RoleMemberResponse>> Handle(RoleMembersQuery request, CancellationToken cancellationToken)
        {

            var role = await Context.Roles.SingleOrDefaultAsync(r => r.Id == request.RoleId);

            if(role == null)
            {
                return null;
            }
            
            var pageNumber = (int)request.PageNumber;
            var pageSize = (int)request.PageSize;

            var roleMembers = Context.RoleMembers.Where(r => r.RoleId == request.RoleId).Join(Context.Users,
                                    r => r.UserId,
                                    u => u.Id,
                                    (r, u) => new
                                    {
                                        User = u,
                                        RoleMember = r
                                    });

            var count = await roleMembers.CountAsync();
            var pagedResults = await roleMembers.OrderBy(s => s.User.DisplayName)
                                                .PageResults(pageNumber, pageSize)
                                                .Select(u => new
                                                {
                                                    Id = u.RoleMember.Id,
                                                    RoleId = request.RoleId,
                                                    UserName = u.User.UserName,
                                                    DisplayName = u.User.DisplayName,
                                                    FirstName = u.User.FirstName,
                                                    LastName = u.User.LastName
                                                }).ToListAsync();
            

            return pagedResults.Select(r => new RoleMemberResponse
            {
                Id = r.Id,
                RoleId = r.RoleId,
                UserName = r.UserName,
                DisplayName = r.DisplayName,
                FirstName = r.FirstName,
                LastName = r.LastName
            }).ToPagedList(count, pageNumber, pageSize);
        }
    }
}
