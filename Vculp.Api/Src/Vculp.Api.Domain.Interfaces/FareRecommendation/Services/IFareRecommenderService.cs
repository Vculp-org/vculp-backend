using System.Threading.Tasks;
using Vculp.Api.Domain.Core.FareRecommendation;

namespace Vculp.Api.Domain.Interfaces.FareRecommendation.Services;

public interface IFareRecommenderService
{
    Task<FareRecommendationDetails> RecommendFareAsync(string origin, string destination, string vehicleType, string vehicleBodyType);
}