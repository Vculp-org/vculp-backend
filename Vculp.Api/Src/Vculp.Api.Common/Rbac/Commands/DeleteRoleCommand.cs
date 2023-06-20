using System;
using MediatR;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Common.Rbac.Commands
{
    public class DeleteRoleCommand : IRequest<ICommandResult>
    {
        public Guid RoleId { get; set; }
    }
}
