using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;

namespace Vculp.Api.Common.Rbac.Commands
{
    public class UpdateRoleCommand : IRequest<ICommandResult<RoleResponse>>
    {
        [FromRoute]
        public Guid RoleId { get; set; }

        [FromBody]
        public UpdateRoleCommandRequestBody Body { get; set; }
    }

    public class UpdateRoleCommandRequestBody
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
