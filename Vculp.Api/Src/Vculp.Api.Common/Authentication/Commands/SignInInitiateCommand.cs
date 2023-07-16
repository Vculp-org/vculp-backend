using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Common.Authentication.Responses;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Authentication.Commands;

public class SignInInitiateCommand : IRequest<Common.ICommandResult<SignInInitiateResponse>>, ICommand
{
    public SignInInitiateCommand()
    {
        CommandId = Guid.NewGuid();
    }

    public string MobileNumber { get; set; }
    [BindNever] public Guid CommandId { get; }

}