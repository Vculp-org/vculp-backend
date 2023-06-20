using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Responses;

namespace Vculp.Api.Common.Rbac.Commands
{
    public class CreateRoleCommand : IRequest<ICommandResult<RoleResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
