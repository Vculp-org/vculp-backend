using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.User
{
    public class CreateUserCommand:IRequest<Common.ICommandResult<UserResponse>>, ICommand
    {
        public CreateUserCommand()
        {
            CommandId = Guid.NewGuid();
        }
        public int ExternalUserId { get;  set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get;  set; }
        public string MobileNumber { get;  set; }

        [BindNever]
        public Guid CommandId { get; }
    }
}