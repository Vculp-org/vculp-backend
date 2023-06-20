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
    public class DeleteUserFromRoleCommandHandler : CommandHandler, IRequestHandler<DeleteUserFromRoleCommand, ICommandResult>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleMemberRepository _roleMemberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserFromRoleCommandHandler
        (
           IRoleRepository roleRepository,
           IRoleMemberRepository roleMemberRepository,
           IUnitOfWork unitOfWork,
           IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _roleMemberRepository = roleMemberRepository ?? throw new ArgumentNullException(nameof(roleMemberRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ICommandResult> Handle(DeleteUserFromRoleCommand request, CancellationToken cancellationToken)
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

            var roleMember = await _roleMemberRepository.GetByIdAsync(request.RoleMemberId);

            if (roleMember == null)
            {
                return new NotFoundCommandResult<ICommandResult>();
            }

            // Delete
            roleMember.Delete();
            _roleMemberRepository.Delete(roleMember);

            await _unitOfWork.SaveChangesAsync();

            // Response
            return new SuccessCommandResult();
        }
    }
}
