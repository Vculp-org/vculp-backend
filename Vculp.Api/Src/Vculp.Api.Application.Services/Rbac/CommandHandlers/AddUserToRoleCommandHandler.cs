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
using Vculp.Api.Common.Rbac.Responses;
using Vculp.Api.Domain.Core.Rbac;

namespace Vculp.Api.Application.Services.Rbac.CommandHandlers
{
    public class AddUserToRoleCommandHandler : CommandHandler, IRequestHandler<AddUserToRoleCommand, ICommandResult<RoleMemberResponse>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleMemberRepository _roleMemberRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<CommandHandlerErrors> _stringLocalizer;

        public AddUserToRoleCommandHandler
        (
           IRoleRepository roleRepository,
           IUserRepository userRepository,
           IRoleMemberRepository roleMemberRepository,
           IUnitOfWork unitOfWork,
           IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _roleMemberRepository = roleMemberRepository ?? throw new ArgumentNullException(nameof(roleMemberRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _stringLocalizer = stringLocalizer ?? throw new ArgumentNullException(nameof(stringLocalizer));
        }

        public async Task<ICommandResult<RoleMemberResponse>> Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var role = await _roleRepository.GetByIdAsync(request.RoleId);

            if(role == null)
            {
                return new NotFoundCommandResult<RoleMemberResponse>();              
            }

            var user = await _userRepository.GetByIdAsync(request.Body.UserId);

            if (user == null)
            {
                return new NotFoundCommandResult<RoleMemberResponse>();
            }

            var isMember = await _roleMemberRepository.IsMemberAsync(request.RoleId, request.Body.UserId);

            if (isMember)
            {
                var conflictResult = new ConflictCommandResult<RoleMemberResponse>();

                conflictResult.AddError(
                    new OperationError(
                        "UserIsAMember",
                        Localizer["AddUserToRoleCommandHandler_UserIsAMember", request.Body.UserId, request.RoleId]));

                return conflictResult;
            }

            var roleMember = new RoleMember(role, user);

            _roleMemberRepository.Add(roleMember);

            await _unitOfWork.SaveChangesAsync();

            var response = new RoleMemberResponse
            {
                Id = roleMember.Id,
                RoleId = request.RoleId,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DisplayName = user.DisplayName
            };

            var successResult = new SuccessCommandResult<RoleMemberResponse>();
            successResult.SetResult(response);

            return successResult;
        }
    }
}
