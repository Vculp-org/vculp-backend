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
    public class UsersQueryHandler : QueryHandler, IRequestHandler<UsersQuery, IPagedList<UserResponse>>
    {
        public UsersQueryHandler(CoreContext context)
           : base(context)
        {
        }

        public async Task<IPagedList<UserResponse>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            var pageNumber = (int)request.PageNumber;
            var pageSize = (int)request.PageSize;

            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                query = query.Where(s => s.DisplayName.Contains(request.Search) ||
                                         s.UserName.Contains(request.Search));
            }

            var count = await query.CountAsync(cancellationToken);

            var users = await query.OrderBy(d => d.DisplayName)
                                   .Select(t => UserMapper.MapTo<UserResponse>(t))
                                   .PageResults(pageNumber, pageSize)
                                   .ToListAsync(cancellationToken);

            return users.ToPagedList(count, pageNumber, pageSize);
        }
    }
}