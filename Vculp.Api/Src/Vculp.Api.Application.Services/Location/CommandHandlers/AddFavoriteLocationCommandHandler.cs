using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Location.Commands;
using Vculp.Api.Domain.Core.Location;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.Location;
using Vculp.Api.Domain.Interfaces.User;

namespace Vculp.Api.Application.Services.Location.CommandHandlers;

public class AddFavoriteLocationCommandHandler : CommandHandler,
    IRequestHandler<AddFavoriteLocationCommand, ICommandResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserAccessor _currentUserAccessor;
    private readonly IFavoriteLocationRepository _favoriteLocationRepository;

    public AddFavoriteLocationCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        ICurrentUserAccessor currentUserAccessor,
        IFavoriteLocationRepository favoriteLocationRepository,
        IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _currentUserAccessor = currentUserAccessor?? throw new ArgumentNullException(nameof(userRepository));
        _favoriteLocationRepository = favoriteLocationRepository?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<ICommandResult> Handle(AddFavoriteLocationCommand request, CancellationToken cancellationToken)
    {

        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        //Check user already exist
        if (!_currentUserAccessor.UserId.HasValue)
        {
            var errResult = new UnauthorisedCommandResult();
            errResult.AddError(new OperationError("InvalidUser", Localizer["InvalidUser"]));
            return errResult;
        }

        //Check user already exist
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            var errResult = new UnprocessableEntityCommandResult();
            errResult.AddError(new OperationError("InvalidUser", Localizer["InvalidUser"]));
            return errResult;
        }

        var location = new FavoriteLocation(request.Latitude, request.Longitude, request.LocationType,
            _currentUserAccessor.UserId.Value);
        // inject location repository
        // save location
        var successResult = new SuccessCommandResult();
        return successResult;
    }
    
}