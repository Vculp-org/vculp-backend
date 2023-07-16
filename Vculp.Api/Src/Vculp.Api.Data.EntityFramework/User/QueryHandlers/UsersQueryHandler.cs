using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Common.User.Mappers;
using Vculp.Api.Common.User.Queries;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Data.EntityFramework.Extensions;
using Vculp.Api.Shared;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Data.EntityFramework.User.QueryHandlers;

public class UsersQueryHandler : QueryHandler, IRequestHandler<UsersQuery, IPagedList<UserResponse>>
{
    public UsersQueryHandler(CoreContext context) : base(context)
    {
    }

    public async Task<IPagedList<UserResponse>> Handle(UsersQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var pageNumber = (int)request.PageNumber;
        var pageSize = (int)request.PageSize;

        var query = Context.Users.AsQueryable();

        if (request.UserId.HasValue)
        {
            query = query.Where(q => q.Id == request.UserId);
        }

        if (!string.IsNullOrWhiteSpace(request.MobileNumber))
        {
            query = query.Where(q => q.MobileNumber == request.MobileNumber);
        }

        if (!string.IsNullOrWhiteSpace(request.EmailAddress))
        {
            query = query.Where(q => q.EmailAddress == request.EmailAddress);
        }

        var count = await query.CountAsync(cancellationToken: cancellationToken);

        var userResponses = await query.OrderBy(q => q.CreationTime).Select(
                response => UserMapper.MapToUserResponse(response))
            .PageResults(pageNumber, pageSize)
            .ToListAsync(cancellationToken: cancellationToken);
        return userResponses.ToPagedList(count, pageNumber, pageSize);
    }
}