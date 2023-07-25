using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Vehicle.Responses;

public class VehicleResponse: LinkedResourceDto
{
    public string Registration { get; set; }
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
}