using System;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Domain.Core.Location
{
    public class Location:Entity
    {
        private Location()
        {
        }

        public Location(decimal latitude, decimal longitude)
        {
            if (latitude < -90 || latitude > 90)
                throw new ArgumentOutOfRangeException("latitude", "latitude should be between -90 to 90");
            if (longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException("longitude", "longitude should be between -180 to 180");
            Latitude = latitude;
            Longitude = longitude;
        }
        public decimal Latitude { get; private set; }
        public decimal Longitude { get; private set; }
    }
}