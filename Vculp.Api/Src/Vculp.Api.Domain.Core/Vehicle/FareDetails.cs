using System;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Domain.Core.Vehicle;

public class FareDetails : ValueObject<FareDetails>
{

    #region Constructors

    private FareDetails()
    {
        State = ObjectState.Unchanged;
    }

    public FareDetails(Vehicle vehicle, string city, double baseFare, double freeKms,
        double perKmFare, double minPerKmFare, double perMinuteFare, double cancellationFeePercentage,
        double cancellationMaxAmount)
    {
        VehicleId = vehicle?.Id ?? throw new ArgumentNullException(nameof(vehicle));
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException($"{nameof(city)} is null, empty or contains only whitespace", nameof(city));
        }

        if (baseFare < 0)
        {
            throw new ArgumentException($"{nameof(baseFare)} cannot be less than zero", nameof(baseFare));
        }

        if (freeKms < 0)
        {
            throw new ArgumentException($"{nameof(freeKms)} cannot be less than zero", nameof(freeKms));
        }

        if (perKmFare < 0)
        {
            throw new ArgumentException($"{nameof(perKmFare)} cannot be less than zero", nameof(perKmFare));
        }

        if (minPerKmFare < 0)
        {
            throw new ArgumentException($"{nameof(minPerKmFare)} cannot be less than zero", nameof(minPerKmFare));
        }

        if (perMinuteFare < 0)
        {
            throw new ArgumentException($"{nameof(perMinuteFare)} cannot be less than zero", nameof(perMinuteFare));
        }

        if (cancellationFeePercentage < 0)
        {
            throw new ArgumentException($"{nameof(cancellationFeePercentage)} cannot be less than zero",
                nameof(cancellationFeePercentage));
        }

        if (cancellationMaxAmount < 0)
        {
            throw new ArgumentException($"{nameof(cancellationMaxAmount)} cannot be less than zero",
                nameof(cancellationMaxAmount));
        }

        City = city;
        BaseFare = baseFare;
        FreeKms = freeKms;
        PerKmFare = perKmFare;
        MinPerKmFare = minPerKmFare;
        PerMinuteFare = perMinuteFare;
        CancellationFeePercentage = cancellationFeePercentage;
        CancellationMaxAmount = cancellationMaxAmount;

    }

    #endregion

    public Guid VehicleId { get; set; }
    public string City { get; set; }
    public double BaseFare { get; set; }
    public double FreeKms { get; set; }
    public double PerKmFare { get; set; }
    public double MinPerKmFare { get; set; }
    public double PerMinuteFare { get; set; }
    public double CancellationFeePercentage { get; set; }
    public double CancellationMaxAmount { get; set; }

    protected override bool EqualsCore(FareDetails other)
    {
        return this.GetHashCode() == other.GetHashCode();
    }

    protected override int GetHashCodeCore()
    {
        return VehicleId.GetHashCode()
               ^ City.GetHashCode() ^ BaseFare.GetHashCode()
               ^ FreeKms.GetHashCode()
               ^ PerKmFare.GetHashCode() ^ MinPerKmFare.GetHashCode()
               ^ PerMinuteFare.GetHashCode()
               ^ CancellationFeePercentage.GetHashCode()
               ^ CancellationMaxAmount.GetHashCode();
    }
}