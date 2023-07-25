using MediatR;
using Vculp.Api.Common.Vehicle.Responses;

namespace Vculp.Api.Common.Vehicle.Queries;

public class NearestQuery: IRequest<VehicleResponse>
{
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
}