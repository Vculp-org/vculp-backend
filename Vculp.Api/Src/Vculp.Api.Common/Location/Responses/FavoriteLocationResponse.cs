using System;
using Newtonsoft.Json;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Location.Responses;

public class FavoriteLocationResponse: LinkedResourceDto
{
    [JsonIgnore] public Guid UserId { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public decimal LocationType { get; set; }
}