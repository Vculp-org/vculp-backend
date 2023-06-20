using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Common.Rbac.Commands
{
    public class RemoveApplicationPermissionFromRoleCommand : IRequest<ICommandResult>
    {
        [FromRoute]
        public Guid RoleId { get; set; }
        [FromRoute]
        public Guid RolePermissionId { get; set; }
    }
}
