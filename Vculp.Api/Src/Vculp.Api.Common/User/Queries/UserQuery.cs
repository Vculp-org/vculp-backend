using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.User.Responses;

namespace Vculp.Api.Common.User.Queries;

public class UserQuery: IRequest<UserResponse>
{
    
    [FromRoute]
    public Guid UserId { get; set; }
    
}