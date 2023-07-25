using System.Collections.Generic;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Location.Responses;

public class NearestDriverResponse:LinkedResourceDto
{
    public string VehicleNumber { get; set; }
    public string Model { get; set; }
    public VehicleType Type { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}