using System;
using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.FareRecommendation.Responses;

public class FareRecommendationResponse: LinkedResourceDto
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public Guid VehicleTypeId { get; set; }
    public double Distance { get; set; }
    public double Duration { get; set; }
    public double BaseFare { get; set; }
    public double BaseFareFreeKms { get; set; }
    public double ActualDistanceAfterFreeKms { get; set; }
    public double DurationFare { get; set; }
    public double MinimumDistanceFare { get; set; }
    public double RecommendedDistanceFare { get; set; }
    public double TollCharges { get; set; }
    public DateTime CreationTime { get;set; }
    public int? CreatedByUserId { get;set; }
    public string CreatedByUserName { get;set; }
    public DateTime LastUpdated { get; set;}
    public int? LastUpdatedByUserId { get;set; }
    public string LastUpdatedByUserName { get;set; }
}