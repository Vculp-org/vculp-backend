using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Booking.Commands;
using Vculp.Api.Common.Booking.Responses;
using Vculp.Api.Common.Caching;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.User;

namespace Vculp.Api.Application.Services.Booking.CommandHandlers;

public class RequestRideCommandHandler : CommandHandler,
    IRequestHandler<RequestRideCommand, ICommandResult<RequestRideCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly ICacheManager _cacheManager;
    private readonly ICurrentUserAccessor _currentUserAccessor;

    public RequestRideCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        ICacheManager cacheManager,
        ICurrentUserAccessor currentUserAccessor,
        IStringLocalizer<CommandHandlerErrors> stringLocalizer)
        : base(stringLocalizer)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _cacheManager = cacheManager?? throw new ArgumentNullException(nameof(cacheManager));
        _currentUserAccessor = currentUserAccessor;
    }

    public async Task<ICommandResult<RequestRideCommandResponse>> Handle(RequestRideCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));
        
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(5)
        };

        await _cacheManager.SetAsync("Test", request, options, cancellationToken);

        var data = await _cacheManager.GetAsync<RequestRideCommand>("Test", cancellationToken);

        //Check user already exist
        if (!_currentUserAccessor.UserId.HasValue)
        {
            var errResult = new UnauthorisedCommandResult<RequestRideCommandResponse>();
            errResult.AddError(new OperationError("InvalidUser", Localizer["InvalidUser"]));
            return errResult;
        }

        var ride = new Domain.Core.Booking.Ride
        (_currentUserAccessor.UserId.Value, request.FromLatitude, request.FromLongitude,
            request.ToLatitude, request.ToLongitude,
            request.VehicleType, request.RequestedFare);
        // var user = new Domain.Core.User.User(externalUserId: request.ExternalUserId,
        //     mobileNumber: request.MobileNumber,
        //     firstName: request.FirstName, lastName: request.LastName);
        //
        // if (!string.IsNullOrWhiteSpace(request.EmailAddress))
        // {
        //     user.ChangeEmail(email: request.EmailAddress);
        // }
        //
        // if (!string.IsNullOrWhiteSpace(request.DateOfBirth))
        // {
        //     request.DateOfBirth.TryParseIso8601DateTimeToUtc(out var date);
        //     user.ChangeDateOfBirth(date);
        // }
        //
        // _userRepository.Add(user);
        // await _unitOfWork.SaveChangesAsync();
        //
        // var response = UserMapper.MapToUserResponse(user);

        var successResult = new SuccessCommandResult<RequestRideCommandResponse>();
        // successResult.SetResult(response);

        return successResult;
    }
}