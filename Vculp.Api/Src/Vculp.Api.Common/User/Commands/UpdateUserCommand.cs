using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.User.Commands;

public class UpdateUserCommand : IRequest<Common.ICommandResult<UserResponse>>, ICommand
{
    public UpdateUserCommand()
    {
        CommandId = Guid.NewGuid();
    }
    
    [BindNever] public Guid CommandId { get; }
    
    public int ExternalUserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string MobileNumber { get; set; }
    public string DateOfBirth { get; set; }
    public bool? IsActive{ get; set; }
}