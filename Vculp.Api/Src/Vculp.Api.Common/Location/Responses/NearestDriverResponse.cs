using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Common.Location.Responses;

public class NearestDriverResponse:LinkedResourceDto
{
    public string VehicleNumber { get; set; }
    public string Model { get; set; }
    public SharedEnums.VehicleType Type { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}