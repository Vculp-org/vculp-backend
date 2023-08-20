using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.FareRecommendation.Commands;
using Vculp.Api.Common.FareRecommendation.Mappers;
using Vculp.Api.Common.FareRecommendation.Responses;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.FareRecommendation;
using Vculp.Api.Domain.Interfaces.FareRecommendation.Services;
using Vculp.Api.Domain.Interfaces.User;

namespace Vculp.Api.Application.Services.FareRecommendation.CommandHandlers;

public class FareRecommendationCommandHandler : CommandHandler,
    IRequestHandler<FareRecommendationCommand, ICommandResult<FareRecommendationResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFareRecommenderService _fareRecommenderService;
    private readonly IFareRecommendationDetailsRepository _fareRecommendationDetailsRepository;

    public FareRecommendationCommandHandler(
        IUnitOfWork unitOfWork,
        IFareRecommenderService fareRecommenderService,
        IFareRecommendationDetailsRepository fareRecommendationDetailsRepository,
        IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _fareRecommenderService =
            fareRecommenderService ?? throw new ArgumentNullException(nameof(fareRecommenderService));
        _fareRecommendationDetailsRepository = fareRecommendationDetailsRepository ??
                                               throw new ArgumentNullException(
                                                   nameof(fareRecommendationDetailsRepository));
    }

    public async Task<ICommandResult<FareRecommendationResponse>> Handle(FareRecommendationCommand request,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        //Call Fare recommender service to get recommnded fare
        var fareRecommendationDetails = await _fareRecommenderService.RecommendFareAsync(request.Origin,
            request.Destination, request.VehicleType,
            request.VehicleBodyType, request.VehicleNoOfSeater);

        _fareRecommendationDetailsRepository.Add(fareRecommendationDetails);
        await _unitOfWork.SaveChangesAsync();

        var response = FareRecommendationDetailsMapper.MapToFareRecommendationResponse(fareRecommendationDetails);

        var successResult = new SuccessCommandResult<FareRecommendationResponse>();
        successResult.SetResult(response);

        return successResult;
    }
}