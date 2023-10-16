using System;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Domain.Core.Location;

public class FavoriteLocation : ActivatableEntity
{
    private FavoriteLocation()
    {
    }

    public FavoriteLocation(decimal latitude, decimal longitude, string locationType, int userId)
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentOutOfRangeException(nameof(latitude), "latitude should be between -90 to 90");
        if (longitude < -180 || longitude > 180)
            throw new ArgumentOutOfRangeException(nameof(longitude), "longitude should be between -180 to 180");
        if (!string.IsNullOrWhiteSpace(locationType))
        {
            throw new ArgumentNullException(nameof(locationType));
        }

        Latitude = latitude;
        Longitude = longitude;
        LocationType = locationType;
        UserId = userId;
    }

    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }
    public string LocationType { get; private set; }
    public int UserId { get; private set; }


    public void ChangeFavLocation(decimal latitude, decimal longitude, string locationType)
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentOutOfRangeException(nameof(latitude), "latitude should be between -90 to 90");
        if (longitude < -180 || longitude > 180)
            throw new ArgumentOutOfRangeException(nameof(longitude), "longitude should be between -180 to 180");
        if (!string.IsNullOrWhiteSpace(locationType))
        {
            throw new ArgumentNullException(nameof(locationType));
        }

        Latitude = latitude;
        Longitude = longitude;
        LocationType = locationType;
        SetStateToUpdated();
    }
}