using System.Threading.Tasks;
using Vculp.Api.Domain.Core.FareRecommendation;

namespace Vculp.Api.Domain.Interfaces.FareRecommendation.Services;

public interface IFareRecommenderService
{
    Task<FareRecommendationDetails> RecommendFareAsync(double origin, double destination,
        string vehicleType, string vehicleBodyType, int? noOfSeater);
}