using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.FareRecommendation.Responses;

public class FareRecommendationResponse: LinkedResourceDto
{
    
    public double RecommendedFare { get; set; }
}