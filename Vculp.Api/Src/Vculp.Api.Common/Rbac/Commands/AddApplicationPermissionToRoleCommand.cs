using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;

namespace Vculp.Api.Common.Rbac.Commands
{
    public class AddApplicationPermissionToRoleCommand : IRequest<ICommandResult<RolePermissionResponse>>
    {
        [FromRoute]
        public Guid RoleId { get; set; }

        [FromBody]
        public AddApplicationPermissionToRoleCommandBody Body { get; set; }
    }

    public class AddApplicationPermissionToRoleCommandBody
    {
        public Guid ApplicationPermissionId { get; set; }
    }
}
