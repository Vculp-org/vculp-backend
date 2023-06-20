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
    public class CreateRoleCommandHandler : CommandHandler, IRequestHandler<CreateRoleCommand, ICommandResult<RoleResponse>>

    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<CommandHandlerErrors> _stringLocalizer;

        public CreateRoleCommandHandler
        (
            IRoleRepository roleRepository,
            IUnitOfWork unitOfWork,
            IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _stringLocalizer = stringLocalizer ?? throw new ArgumentNullException(nameof(stringLocalizer));
        }

        public async Task<ICommandResult<RoleResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var isExists = await _roleRepository.ExistsAsync(request.Name);

            if(isExists)
            {
                var conflictResult = new ConflictCommandResult<RoleResponse>();

                conflictResult.AddError(
                    new OperationError(
                        "RoleNameIsInUse",
                        Localizer["CreateRoleCommandHandler_RoleNameIsInUse", request.Name]));

                return conflictResult;
            }

            var role = new Role(request.Name, request.Description);

            _roleRepository.Add(role);
            await _unitOfWork.SaveChangesAsync();

            var response = RoleMapper.MapToRoleResponse(role);

            var successResult = new SuccessCommandResult<RoleResponse>();
            successResult.SetResult(response);

            return successResult;

        }
    }
}
