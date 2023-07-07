using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Shared.Abstractions.Paging;

namespace Vculp.Api.Common.User.Queries;

public class UsersQuery: PagedResourceParameters, IRequest<IPagedList<UserResponse>>
{
    public UsersQuery()
        : base(10, 20)
    {
    }

    [FromQuery]
    public string EmailAddress { get; set; }
    
    [FromQuery]
    public Guid? UserId { get; set; }

    [FromQuery]
    public string MobileNumber { get; set; }
}