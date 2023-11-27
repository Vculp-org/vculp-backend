using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.FavoriteRegion.Responses
{
    public class FavoriteRegionResponse: LinkedResourceDto
    {
        public Guid FavoriteRegionId { get; set; }
        public string Name { get; set; }
        public string AreaName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Radius { get; set; }
        [JsonIgnore] public Guid UserId { get; set; }
    }
}
