using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Rbac.Commands;
using Vculp.Api.Common.Rbac.Mappers;
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.Rbac.Repositories;

namespace Vculp.Api.Application.Services.Rbac.CommandHandlers
{
    public class UpdateRoleCommandHandler : CommandHandler, IRequestHandler<UpdateRoleCommand, ICommandResult<RoleResponse>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<CommandHandlerErrors> _stringLocalizer;

        public UpdateRoleCommandHandler
        (
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork,
            IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _stringLocalizer = stringLocalizer ?? throw new ArgumentNullException(nameof(stringLocalizer));
        }

        public async Task<ICommandResult<RoleResponse>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var role = await _roleRepository.GetByIdAsync(request.RoleId);

            if (role == null)
            {
                return new NotFoundCommandResult<RoleResponse>();
            }

            var isExists = await _roleRepository.ExistsWithNameButIdAsync(request.RoleId, request.Body.Name);

            if (isExists)
            {
                var conflictResult = new ConflictCommandResult<RoleResponse>();

                conflictResult.AddError(
                    new OperationError(
                        "RoleNameIsInUse",
                        Localizer["UpdateRoleCommandHandler_RoleNameIsInUse", request.Body.Name]));

                return conflictResult;
            }

            role.ChangeName(request.Body.Name);
            role.ChangeDescription(request.Body.Description);

            _roleRepository.Update(role);
            await _unitOfWork.SaveChangesAsync();

            var response = RoleMapper.MapToRoleResponse(role);

            var successResult = new SuccessCommandResult<RoleResponse>();
            successResult.SetResult(response);

            return successResult;


        }
    }
}
