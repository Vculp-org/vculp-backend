using System.Threading.Tasks;

namespace Vculp.Api.Domain.Interfaces.FareRecommendation.Services;

public interface IFareRecommenderService
{
    Task RecommendFareAsync(string origin, string destination, string vehicleType, string vehicleBodyType);
}