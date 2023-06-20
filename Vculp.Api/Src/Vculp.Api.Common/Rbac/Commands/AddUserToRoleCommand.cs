using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;

namespace Vculp.Api.Common.Rbac.Commands
{
    public class AddUserToRoleCommand : IRequest<ICommandResult<RoleMemberResponse>>
    {
        [FromRoute]
        public Guid RoleId { get; set; }

        [FromBody]
        public AddUserToRoleCommandRequestBody Body { get; set; }
    }

    public class AddUserToRoleCommandRequestBody
    {
        public Guid UserId { get; set; }
    }
}
