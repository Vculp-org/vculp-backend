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
using Vculp.Api.Domain.Interfaces.Booking;
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
    private readonly IRideRepository _rideRepository;

    public RequestRideCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        ICacheManager cacheManager,
        ICurrentUserAccessor currentUserAccessor,
        IRideRepository rideRepository,
        IStringLocalizer<CommandHandlerErrors> stringLocalizer)
        : base(stringLocalizer)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _cacheManager = cacheManager?? throw new ArgumentNullException(nameof(cacheManager));
        _currentUserAccessor = currentUserAccessor;
        _rideRepository = rideRepository;
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
        _rideRepository.Add(ride);
        await _unitOfWork.SaveChangesAsync();

        var successResult = new SuccessCommandResult<RequestRideCommandResponse>();
        successResult.SetResult(new RequestRideCommandResponse { Ride = ride });

        return successResult;
    }
}