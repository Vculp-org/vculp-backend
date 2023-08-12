using Vculp.Api.Domain.Interfaces.FareRecommendation.Services;
using Vculp.Api.Domain.Interfaces.GoogleMaps;

namespace Vculp.Api.Domain.FareRecommendation.Services;

public class FareRecommenderService : IFareRecommenderService
{
    private readonly IDistanceMatrixApi _distanceMatrixApi;

    public FareRecommenderService(IDistanceMatrixApi distanceMatrixApi)
    {
        _distanceMatrixApi = distanceMatrixApi;
    }

    public async void RecommendFare(string origin, string destination)
    {
        var distanceApiResponse = await _distanceMatrixApi.GetAsync(origin, destination);
    }
}