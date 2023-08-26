using System;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;
using Vculp.Api.Domain.Core.User;
using Vculp.Api.Domain.Core.Vehicle;

namespace Vculp.Api.Domain.Core.Booking;

public class Ride: AggregateRoot, ICreationAuditable, IUpdateAuditable
{
    #region Constructors

    public Ride()
    {
        State = ObjectState.Unchanged;
    }

    public Ride(Guid userId, decimal fromLatitude, decimal fromLongitude, decimal toLatitude, decimal toLongitude, VehicleType vehicleType, decimal requestedFare)
    {
        if (fromLatitude < -90 || fromLatitude > 90)
            throw new ArgumentException("From Latitude should be within the range of -90 to 90");
        if (fromLongitude < -180 || fromLongitude > 180)
            throw new ArgumentException("From Longitude should be within the range of -180 to 180");
        if (toLatitude < -90 || toLatitude > 90)
            throw new ArgumentException("To Latitude should be within the range of -90 to 90");
        if (toLongitude < -180 || toLongitude > 180)
            throw new ArgumentException("To Longitude should be within the range of -180 to 180");
        if (requestedFare <= 0)
            throw new ArgumentException("Requested fare should higher than 0 value");
        
        VehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), vehicleType.ToString(), true);
        UserId = userId;
        FromLatitude = fromLatitude;
        FromLongitude = fromLongitude;
        ToLatitude = toLatitude;
        ToLongitude = toLatitude;
        RequestedFare = requestedFare;
    }

    #endregion

    #region Properties
    public Guid UserId { get; private set; }
    public decimal FromLatitude { get; private set; }
    public decimal FromLongitude { get; private set; }
    public decimal ToLatitude { get; private set; }
    public decimal ToLongitude { get; private set; }
    public VehicleType VehicleType { get; private set; }
    public decimal RequestedFare { get; private set; }

    public DateTime CreationTime { get; private set;}
    public int? CreatedByUserId { get; private set;}
    public string CreatedByUserName { get; private set;}
    public DateTime LastUpdated { get; private set;}
    public int? LastUpdatedByUserId { get; private set;}
    public string LastUpdatedByUserName { get; private set;}

    #endregion
}