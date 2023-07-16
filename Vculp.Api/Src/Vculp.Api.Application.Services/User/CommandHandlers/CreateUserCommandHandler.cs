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

public class CreateUserCommandHandler : CommandHandler,
    IRequestHandler<CreateUserCommand, ICommandResult<UserResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IStringLocalizer<CommandHandlerErrors> stringLocalizer)
        : base(stringLocalizer)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<ICommandResult<UserResponse>> Handle(CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        //Check user already exist
        var isExists = await _userRepository.ExistAsync(request.MobileNumber);

        if (isExists)
        {
            var conflictResult = new ConflictCommandResult<UserResponse>();

            conflictResult.AddError(
                new OperationError(
                    "MobileIsInUse",
                    Localizer["CreateUserCommandHandler_MobileIsInUse", request.MobileNumber]));

            return conflictResult;
        }

        var user = new Domain.Core.User.User(externalUserId: request.ExternalUserId,
            mobileNumber: request.MobileNumber,
            firstName: request.FirstName, lastName: request.LastName);

        if (!string.IsNullOrWhiteSpace(request.EmailAddress))
        {
            user.ChangeEmail(email: request.EmailAddress);
        }

        if (!string.IsNullOrWhiteSpace(request.DateOfBirth))
        {
            request.DateOfBirth.TryParseIso8601DateTimeToUtc(out var date);
            user.ChangeDateOfBirth(date);
        }

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync();

        var response = UserMapper.MapToUserResponse(user);

        var successResult = new SuccessCommandResult<UserResponse>();
        successResult.SetResult(response);

        return successResult;
    }
}