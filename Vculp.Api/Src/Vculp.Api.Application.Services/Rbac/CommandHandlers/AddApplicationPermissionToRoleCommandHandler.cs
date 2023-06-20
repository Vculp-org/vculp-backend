using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.Rbac.Repositories;
using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Commands;
using Vculp.Api.Common.Rbac.Mappers;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Application.Services.Rbac.CommandHandlers
{
    public class AddApplicationPermissionToRoleCommandHandler : CommandHandler, IRequestHandler<AddApplicationPermissionToRoleCommand, ICommandResult<RolePermissionResponse>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IApplicationPermissionRepository _applicationPermissionRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddApplicationPermissionToRoleCommandHandler
        (
            IRoleRepository roleRepository,
            IApplicationPermissionRepository applicationPermissionRepository,
            IRolePermissionRepository rolePermissionRepository,
            IUnitOfWork unitOfWork,
            IStringLocalizer<CommandHandlerErrors> stringLocalizer
        ) 
            : base(stringLocalizer)
        {
            _roleRepository= roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _applicationPermissionRepository = applicationPermissionRepository ?? throw new ArgumentNullException(nameof(applicationPermissionRepository));
            _rolePermissionRepository = rolePermissionRepository ?? throw new ArgumentNullException(nameof(rolePermissionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ICommandResult<RolePermissionResponse>> Handle(AddApplicationPermissionToRoleCommand request, CancellationToken cancellationToken)
        {
            if (request.RoleId == Guid.Empty)
            {
                return new NotFoundCommandResult<RolePermissionResponse>();
            }

            var role = await _roleRepository.GetByIdAsync(request.RoleId);

            if (role == null)
            {
                return new NotFoundCommandResult<RolePermissionResponse>();
            }

            var applicationPermission = await _applicationPermissionRepository.GetByIdAsync(request.Body.ApplicationPermissionId);

            if (applicationPermission == null)
            {
                var unprocessableEntityResult = new UnprocessableEntityCommandResult<RolePermissionResponse>();
                unprocessableEntityResult.AddError(
                    new OperationError(
                        $"{nameof(request.Body.ApplicationPermissionId)}",
                        Localizer["FieldDataNotFound", nameof(ApplicationPermission)]));

                return unprocessableEntityResult;
            }

            var rolePermissionExist = await _rolePermissionRepository.RolePermissionExistAsync(request.RoleId, applicationPermission.Id);

            if (rolePermissionExist)
            {
                var conflictCommandResult = new ConflictCommandResult<RolePermissionResponse>();
                conflictCommandResult.AddError(
                    new OperationError(
                        $"{nameof(request.Body.ApplicationPermissionId)}",
                        Localizer["CreateApplicationPermissionCommandHandler_ApplicationPermissionAlreadyAssignedToTheRole", request.Body.ApplicationPermissionId]));

                return conflictCommandResult;
            }

            var rolePermission = new RolePermission(role, applicationPermission);

            _rolePermissionRepository.Add(rolePermission);

            await _unitOfWork.SaveChangesAsync();

            var result = RolePermissionMapper.MapToRolePermissionResponse(rolePermission, applicationPermission);                                 

            var successResult = new SuccessCommandResult<RolePermissionResponse>();
            successResult.SetResult(result);
            return successResult;
        }
    }
}
