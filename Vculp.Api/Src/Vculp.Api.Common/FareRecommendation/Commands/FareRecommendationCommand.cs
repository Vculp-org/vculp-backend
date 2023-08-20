using MediatR;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.FareRecommendation.Responses;

namespace Vculp.Api.Common.FareRecommendation.Commands;

public class FareRecommendationCommand: IRequest<ICommandResult<FareRecommendationResponse>>
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string VehicleType { get; set; }
    public string VehicleBodyType { get; set; }
    public int? VehicleNoOfSeater { get; set; }
    
}