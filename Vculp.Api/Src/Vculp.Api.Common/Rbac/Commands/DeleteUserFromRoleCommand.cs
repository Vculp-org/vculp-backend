using System;
using MediatR;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Common.Rbac.Commands
{
    public class DeleteUserFromRoleCommand : IRequest<ICommandResult>
    {
        public Guid RoleId { get; set; }
        public Guid RoleMemberId { get; set; }
    }
}
