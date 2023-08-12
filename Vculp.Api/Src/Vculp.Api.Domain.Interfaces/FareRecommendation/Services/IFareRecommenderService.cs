namespace Vculp.Api.Domain.Interfaces.FareRecommendation.Services;

public interface IFareRecommenderService
{
    void RecommendFare(string origin, string destination);
}