using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.FareRecommendation.Commands;
using Vculp.Api.Common.FareRecommendation.Responses;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.FareRecommendation.Services;
using Vculp.Api.Domain.Interfaces.User;

namespace Vculp.Api.Application.Services.FareRecommendation.CommandHandlers;

public class FareRecommendationCommandHandler : CommandHandler,
    IRequestHandler<FareRecommendationCommand, ICommandResult<FareRecommendationResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFareRecommenderService _fareRecommenderService;

    public FareRecommendationCommandHandler(
        IUnitOfWork unitOfWork,
        IFareRecommenderService fareRecommenderService,
        IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _fareRecommenderService =
            fareRecommenderService ?? throw new ArgumentNullException(nameof(fareRecommenderService));
    }

    public async Task<ICommandResult<FareRecommendationResponse>> Handle(FareRecommendationCommand request,
        CancellationToken cancellationToken)
    {
       
        //Call Fare recommonder service to get recommnded fare
      await _fareRecommenderService.RecommendFareAsync(request.Origin, request.Destination, request.VehicleType,
            request.VehicleBodyType);

      throw new NotImplementedException();

    }
}