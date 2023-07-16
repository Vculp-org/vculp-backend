using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Common.Authentication.Responses;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Authentication.Commands;

public class SignInCompleteCommand: IRequest<Common.ICommandResult<SignInCompleteResponse>>, ICommand
{
    public SignInCompleteCommand()
    {
        CommandId = Guid.NewGuid();
    }

    public string MobileNumber { get; set; }
    
    public int OneTimePassword { get; set; }

    [BindNever] public Guid CommandId { get; }
}