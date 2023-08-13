using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Vculp.Api.Domain.Core.FareRecommendation;
using Vculp.Api.Domain.Interfaces.FareRecommendation.Services;
using Vculp.Api.Domain.Interfaces.GoogleMaps;
using Vculp.Api.Domain.Interfaces.Vehicle;

namespace Vculp.Api.Domain.FareRecommendation.Services;

public class FareRecommenderService : IFareRecommenderService
{
    private readonly IDistanceMatrixApi _distanceMatrixApi;
    private readonly IVehicleTypeRepository _vehicleRepository;

    public FareRecommenderService(IDistanceMatrixApi distanceMatrixApi, IVehicleTypeRepository vehicleRepository)
    {
        _distanceMatrixApi = distanceMatrixApi ?? throw new ArgumentNullException(nameof(distanceMatrixApi));
        _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
    }

    public async Task<FareRecommendationDetails> RecommendFareAsync(string origin, string destination,
        string vehicleType, string vehicleBodyType)
    {
        var distanceApiResponse = await _distanceMatrixApi.GetAsync(origin, destination);

        var element = distanceApiResponse.Rows.FirstOrDefault()?.Elements.FirstOrDefault();

        var fareDetails = await _vehicleRepository.GetVehicleFareDetails(vehicleType, vehicleBodyType, origin);

        //Logic
        //(Cost per minute * time in ride) + (Cost per km * ride distance) + BaseFare + Toll Rates = Your Fare

        //Base Fare - Min Fare to be added per vehicle category
        var baseFare = fareDetails.BaseFare;
        //Free Kms included in base fare, so that we can subtract the free kms from actual trip distance.
        var baseFareFreeKms = fareDetails.FreeKms;
        //Duration/Time fare factor - (Cost per minute * time in ride)
        var durationFare = element?.Duration.Value * fareDetails.PerMinuteFare;
        //Actual Distance after base fare included free kms 
        var actualDistanceAfterFreeBaseFareKms = element?.Distance.Value - baseFareFreeKms;
        //Distance fare factor - (Cost per km * ride distance(actual ride distance))
        var minDistanceFare = fareDetails.MinPerKmFare * actualDistanceAfterFreeBaseFareKms;
        var recommendedDistanceFare = fareDetails.PerKmFare * actualDistanceAfterFreeBaseFareKms;
        //Toll Rates
        const double
            tollRate = 0d; // This will be some dynamic value based on toll rate and the region where rider cross the border.

        var yourMinimumFare = baseFare + durationFare + durationFare + minDistanceFare + tollRate;
        var yourRecommendedFare = baseFare + durationFare + durationFare + recommendedDistanceFare + tollRate;

        var fareRecommendationDetails = new FareRecommendationDetails(origin, destination, element?.Distance.Value ?? 0,
            element?.Duration.Value ?? 0
            , baseFare, baseFareFreeKms, actualDistanceAfterFreeBaseFareKms.GetValueOrDefault(),
            durationFare.GetValueOrDefault(), minDistanceFare.GetValueOrDefault(),
            recommendedDistanceFare.GetValueOrDefault(), tollRate);

        return fareRecommendationDetails;
    }
}