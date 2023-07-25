using System;
using System.Text.Json.Serialization;
using Vculp.Api.Common.Common.Dtos;
using Vculp.Api.Domain.Core.Geo;

namespace Vculp.Api.Common.User.Responses
{

    public class LocationResponse : LinkedResourceDto
    {
        [JsonIgnore] public Guid LocationId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}   