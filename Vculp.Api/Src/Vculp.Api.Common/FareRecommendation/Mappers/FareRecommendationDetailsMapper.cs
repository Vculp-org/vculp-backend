using Vculp.Api.Common.Common;
using Vculp.Api.Common.FareRecommendation.Responses;
using Vculp.Api.Domain.Core.FareRecommendation;

namespace Vculp.Api.Common.FareRecommendation.Mappers;

public class FareRecommendationDetailsMapper : Mapper<FareRecommendationDetails>
{
    static FareRecommendationDetailsMapper()
    {
        CreateMapTo<FareRecommendationResponse>(MapToFareRecommendationResponse);
    }

    new public static TDestination MapTo<TDestination>(FareRecommendationDetails source)
        => Mapper<FareRecommendationDetails>.MapTo<TDestination>(source);

    public static FareRecommendationResponse MapToFareRecommendationResponse(
        FareRecommendationDetails fareRecommendationDetails)
    {
        return new FareRecommendationResponse()
        {
            Destination = fareRecommendationDetails.Destination,
            Distance = fareRecommendationDetails.Distance,
            Duration = fareRecommendationDetails.Duration,
            Origin = fareRecommendationDetails.Origin,
            BaseFare = fareRecommendationDetails.BaseFare,
            DurationFare = fareRecommendationDetails.DurationFare,
            TollCharges = fareRecommendationDetails.TollCharges,
            MinimumDistanceFare = fareRecommendationDetails.MinimumDistanceFare,
            RecommendedDistanceFare = fareRecommendationDetails.RecommendedDistanceFare,
            VehicleTypeId = fareRecommendationDetails.VehicleTypeId,
            BaseFareFreeKms = fareRecommendationDetails.BaseFareFreeKms,
            ActualDistanceAfterFreeKms = fareRecommendationDetails.ActualDistanceAfterFreeKms
        };
    }
}