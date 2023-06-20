using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Commands;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.Rbac.Repositories;

namespace Vculp.Api.Application.Services.Rbac.CommandHandlers
{
    public class DeleteRoleCommandHandler : CommandHandler, IRequestHandler<DeleteRoleCommand, ICommandResult>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleCommandHandler
        (
           IRoleRepository roleRepository,
           IUnitOfWork unitOfWork,
           IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ICommandResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var role = await _roleRepository.GetByIdAsync(request.RoleId);

            if (role == null)
            {
                return new NotFoundCommandResult<ICommandResult>();
            }

            // Delete Role Permission
            role.Delete();
            _roleRepository.DeleteRole(role);

            await _unitOfWork.SaveChangesAsync();

            // Response
            return new SuccessCommandResult();
        }
    }
}
