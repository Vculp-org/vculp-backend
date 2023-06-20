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
    public class RemoveApplicationPermissionFromRoleCommandHandler : CommandHandler, IRequestHandler<RemoveApplicationPermissionFromRoleCommand, ICommandResult>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveApplicationPermissionFromRoleCommandHandler(
            IRoleRepository roleRepository,
            IRolePermissionRepository rolePermissionRepository,
            IUnitOfWork unitOfWork,
            IStringLocalizer<CommandHandlerErrors> stringLocalizer)
            : base(stringLocalizer)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _rolePermissionRepository = rolePermissionRepository ?? throw new ArgumentNullException(nameof(rolePermissionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ICommandResult> Handle(RemoveApplicationPermissionFromRoleCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var role = await _roleRepository.GetByIdAsync(request.RoleId);

            if (role == null)
            {
                return new NotFoundCommandResult();
            }

            var rolePermission = await _rolePermissionRepository.GetByIdAsync(request.RolePermissionId);

            if (rolePermission == null)
            {
                return new NotFoundCommandResult();
            }

            rolePermission.Delete();
            _rolePermissionRepository.Delete(rolePermission);

            await _unitOfWork.SaveChangesAsync();

            var successResult = new SuccessCommandResult();

            return successResult;
        }
    }
}
