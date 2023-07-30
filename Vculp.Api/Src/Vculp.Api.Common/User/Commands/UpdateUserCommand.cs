using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.User.Responses;

namespace Vculp.Api.Common.User.Commands;

public class UpdateUserCommand : IRequest<ICommandResult<UserResponse>>
{
    [FromRoute(Name = "userId")]
    public Guid UserId { get; set; }
    
    [FromBody]
    public UpdateUserRequestBody Body { get; set; }
}


public class UpdateUserRequestBody
{
    //public int ExternalUserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    //public string MobileNumber { get; set; }
    public string DateOfBirth { get; set; }
    public bool? IsActive{ get; set; }
}