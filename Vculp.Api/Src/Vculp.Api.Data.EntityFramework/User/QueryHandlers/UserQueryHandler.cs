using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vculp.Api.Common.User.Mappers;
using Vculp.Api.Common.User.Queries;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Data.EntityFramework.Common;

namespace Vculp.Api.Data.EntityFramework.User.QueryHandlers;

public class UserQueryHandler: QueryHandler, IRequestHandler<UserQuery, UserResponse>
{
    public UserQueryHandler(CoreContext context) : base(context)
    {
    }

    public async Task<UserResponse> Handle(UserQuery request, CancellationToken cancellationToken)
    
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var user = await Context.Users.SingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken: cancellationToken);

        if (user == null)
        {
            return null;
        }

        var userResponse = UserMapper.MapToUserResponse(user);
        return userResponse;
    }
}