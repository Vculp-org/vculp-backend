using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.GoogleMaps.Configs;
using Vculp.Api.Domain.Core.FareRecommendation;
using Vculp.Api.Domain.Interfaces.FareRecommendation.Services;
using Vculp.Api.Domain.Interfaces.GoogleMaps;
using Vculp.Api.Domain.Interfaces.Vehicle;

namespace Vculp.Api.Domain.FareRecommendation.Services;

public class FareRecommenderService : IFareRecommenderService
{
    private readonly IDistanceMatrixApi _distanceMatrixApi;
    private readonly IVehicleTypeRepository _vehicleRepository;
    private readonly ICurrentUserAccessor _currentUserAccessor;
    private readonly GoogleMapsConfiguration _googleMapsConfiguration;

    public FareRecommenderService(IDistanceMatrixApi distanceMatrixApi,
        IVehicleTypeRepository vehicleRepository,
        ICurrentUserAccessor currentUserAccessor,
        IOptions<GoogleMapsConfiguration> googleMapsOptions)
    {
        _distanceMatrixApi = distanceMatrixApi ?? throw new ArgumentNullException(nameof(distanceMatrixApi));
        _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
        _currentUserAccessor = currentUserAccessor?? throw new ArgumentNullException(nameof(currentUserAccessor));
        _googleMapsConfiguration = googleMapsOptions.Value?? throw new ArgumentNullException(nameof(googleMapsOptions));
    }

    public async Task<FareRecommendationDetails> RecommendFareAsync(double origin, double destination,
        string vehicleType, string vehicleBodyType, int? noOfSeater)
    {
        var query = new DistanceMatrixQueryParams
        {
            Key = _googleMapsConfiguration.ApiKey,
            Origins = $"<{origin}>",
            Destinations = $"<{destination}>"
        };
        var distanceApiResponse = await _distanceMatrixApi.GetAsync(query);

        var element = distanceApiResponse.Rows.FirstOrDefault()?.Elements.FirstOrDefault();

        var vehicleTypeDetails =
            await _vehicleRepository.GetVehicleType(vehicleType, vehicleBodyType, origin, noOfSeater);
        var fareDetails = vehicleTypeDetails.FareDetails.FirstOrDefault(q => q.Origin==origin);
        if (fareDetails == null)
        {
            return null;
        }
        
        //Logic
        //(Cost per minute * time in ride) + (Cost per km * ride distance) + BaseFare + Toll Rates = Your Fare

        //Base Fare - Min Fare to be added per vehicle category
        var baseFare = fareDetails.BaseFare;
        //Free Kms included in base fare, so that we can subtract the free kms from actual trip distance.
        var baseFareFreeKms = fareDetails.FreeKms;
        //Duration/Time fare factor - (Cost per minute * time in ride)
        var durationFare = element?.Duration.Value * (fareDetails.PerMinuteFare/60);
        //Actual Distance after base fare included free kms 
        var actualDistanceAfterFreeBaseFareKms = element?.Distance.Value - (baseFareFreeKms*1000);
        //Distance fare factor - (Cost per km * ride distance(actual ride distance))
        var minDistanceFare = (fareDetails.MinPerKmFare/1000) * actualDistanceAfterFreeBaseFareKms;
        var recommendedDistanceFare = (fareDetails.PerKmFare/1000) * actualDistanceAfterFreeBaseFareKms;
        //Toll Rates
        const double
            tollRate = 0d; // This will be some dynamic value based on toll rate and the region where rider cross the border.

        var yourMinimumFare = baseFare + durationFare + durationFare + minDistanceFare + tollRate;
        var yourRecommendedFare = baseFare + durationFare + durationFare + recommendedDistanceFare + tollRate;
        var user = _currentUserAccessor.UserId.GetValueOrDefault();
        var fareRecommendationDetails = new FareRecommendationDetails(user, origin, destination,
            element?.Distance.Value ?? 0,
            element?.Duration.Value ?? 0
            , baseFare, baseFareFreeKms, actualDistanceAfterFreeBaseFareKms.GetValueOrDefault(),
            durationFare.GetValueOrDefault(), minDistanceFare.GetValueOrDefault(),
            recommendedDistanceFare.GetValueOrDefault(), tollRate, yourRecommendedFare.GetValueOrDefault(),
            yourMinimumFare.GetValueOrDefault());

        return fareRecommendationDetails;
    }
}