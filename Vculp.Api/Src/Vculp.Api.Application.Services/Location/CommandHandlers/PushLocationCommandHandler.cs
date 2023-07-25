using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Location.Commands;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.User;

namespace Vculp.Api.Application.Services.Location.CommandHandlers;

public class PushLocationCommandHandler:CommandHandler,
    IRequestHandler<PushLocationCommand, ICommandResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public PushLocationCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<ICommandResult> Handle(PushLocationCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        //Check user already exist
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            var errResult = new UnprocessableEntityCommandResult();
            errResult.AddError(new OperationError("InvalidUser", Localizer["InvalidUser"]));
            return errResult;
        }

        var location = new Domain.Core.Geo.Location(request.Latitude, request.Longitude);
        // inject location repository
        // save location
        var successResult = new SuccessCommandResult();
        return successResult;
    }
}