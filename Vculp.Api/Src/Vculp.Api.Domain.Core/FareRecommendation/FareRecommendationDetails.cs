using System;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.FareRecommendation;

public class FareRecommendationDetails : AggregateRoot, ICreationAuditable, IUpdateAuditable
{

    #region Constructors

    protected FareRecommendationDetails()
    {
        State = ObjectState.Unchanged;
    }

    public FareRecommendationDetails(int userId, double origin, double destination, double distance,
        double duration, double baseFare, double baseFareFreeKms, double actualDistanceAfterFreeKms,
        double durationFare, double minimumDistanceFare, double recommendedDistanceFare,
        double tollCharges, double yourRecommendedFare, double yourMinimumFare)
    {
        // if (string.IsNullOrWhiteSpace(origin))
        // {
        //     throw new ArgumentException($"{nameof(origin)} cannot be an empty name", nameof(origin));
        // }
        //
        // if (string.IsNullOrWhiteSpace(destination))
        // {
        //     throw new ArgumentException($"{nameof(destination)} cannot be an empty name", nameof(destination));
        // }

        if (distance < 0)
        {
            throw new ArgumentException($"{nameof(distance)} cannot be less than zero", nameof(distance));
        }

        if (duration < 0)
        {
            throw new ArgumentException($"{nameof(duration)} cannot be less than zero", nameof(duration));
        }

        if (baseFare < 0)
        {
            throw new ArgumentException($"{nameof(baseFare)} cannot be less than zero", nameof(baseFare));
        }

        if (baseFareFreeKms < 0)
        {
            throw new ArgumentException($"{nameof(baseFareFreeKms)} cannot be less than zero", nameof(baseFareFreeKms));
        }

        if (actualDistanceAfterFreeKms < 0)
        {
            throw new ArgumentException($"{nameof(actualDistanceAfterFreeKms)} cannot be less than zero",
                nameof(actualDistanceAfterFreeKms));
        }

        if (durationFare < 0)
        {
            throw new ArgumentException($"{nameof(durationFare)} cannot be less than zero", nameof(durationFare));
        }

        if (minimumDistanceFare < 0)
        {
            throw new ArgumentException($"{nameof(minimumDistanceFare)} cannot be less than zero",
                nameof(minimumDistanceFare));
        }

        if (tollCharges < 0)
        {
            throw new ArgumentException($"{nameof(tollCharges)} cannot be less than zero", nameof(tollCharges));
        }
        
        if (yourMinimumFare < 0)
        {
            throw new ArgumentException($"{nameof(yourMinimumFare)} cannot be less than zero", nameof(yourMinimumFare));
        }
        
        if (yourRecommendedFare < 0)
        {
            throw new ArgumentException($"{nameof(yourRecommendedFare)} cannot be less than zero", nameof(yourRecommendedFare));
        }
        

        UserId = userId;
        Origin = origin;
        Destination = destination;
        Distance = distance;
        Duration = duration;
        BaseFare = baseFare;
        BaseFareFreeKms = baseFareFreeKms;
        ActualDistanceAfterFreeKms = actualDistanceAfterFreeKms;
        DurationFare = durationFare;
        MinimumDistanceFare = minimumDistanceFare;
        RecommendedDistanceFare = recommendedDistanceFare;
        TollCharges = tollCharges;
        YourMinimumFare = yourMinimumFare;
        YourRecommendedFare = yourRecommendedFare;

    }

    #endregion

    #region Properties

    public int UserId { get; set; }
    public double Origin { get; set; }
    public double Destination { get; set; }
    public Guid VehicleTypeId { get; set; }
    public double Distance { get; set; }
    public double Duration { get; set; }
    public double BaseFare { get; set; }
    public double BaseFareFreeKms { get; set; }
    public double ActualDistanceAfterFreeKms { get; set; }
    public double DurationFare { get; set; }
    public double MinimumDistanceFare { get; set; }
    public double RecommendedDistanceFare { get; set; }
    public double YourMinimumFare { get; set; }
    public double YourRecommendedFare { get; set; }
    public double TollCharges { get; set; }
    public DateTime CreationTime { get; }
    public int? CreatedByUserId { get; }
    public string CreatedByUserName { get; }
    public DateTime LastUpdated { get; }
    public int? LastUpdatedByUserId { get; }
    public string LastUpdatedByUserName { get; }

    #endregion
}