using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.User.Commands;
using Vculp.Api.Common.User.Mappers;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.User;
using Vculp.Extensions.String;

namespace Vculp.Api.Application.Services.User.CommandHandlers;

public class UpdateUserCommandHandler : CommandHandler,
    IRequestHandler<UpdateUserCommand, ICommandResult<UserResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IStringLocalizer<CommandHandlerErrors> stringLocalizer)
        : base(stringLocalizer)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<ICommandResult<UserResponse>> Handle(UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        //Check user exist
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            return new NotFoundCommandResult<UserResponse>();
        }

        //Email
        if (!string.IsNullOrWhiteSpace(request.Body.EmailAddress))
        {
            user.ChangeEmail(email: request.Body.EmailAddress);
        }

        if (!string.IsNullOrWhiteSpace(request.Body.DateOfBirth))
        {
            request.Body.DateOfBirth.TryParseIso8601DateTimeToUtc(out var date);
            user.ChangeDateOfBirth(date);
        }

        if (!string.IsNullOrWhiteSpace(request.Body.FirstName))
        {
            user.ChangeFirstName(request.Body.FirstName);
        }

        if (!string.IsNullOrWhiteSpace(request.Body.LastName))
        {
            user.ChangeLastName(request.Body.LastName);
        }

        if (request.Body.IsActive.HasValue)
            user.Activate();
        else
            user.Deactivate();

        await _unitOfWork.SaveChangesAsync();

        var response = UserMapper.MapToUserResponse(user);

        var successResult = new SuccessCommandResult<UserResponse>();
        successResult.SetResult(response);

        return successResult;
    }
}