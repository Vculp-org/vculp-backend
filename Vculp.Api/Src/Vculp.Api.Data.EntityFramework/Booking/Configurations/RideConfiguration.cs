using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Booking;

namespace Vculp.Api.Data.EntityFramework.Booking.Configurations;

public class RideConfiguration : EntityConfiguration<Ride>
{
    public RideConfiguration(CoreContext context) : base(context)
    {
    }

    protected override string SchemaName => "Booking";
    protected override string TableName => "Rides";

    public override void Configure(EntityTypeBuilder<Ride> builder)
    {
        base.Configure(builder);

        builder.Property(i => i.UserId).IsRequired();
        builder.Property(i => i.FromLatitude).IsRequired();
        builder.Property(i => i.FromLongitude).IsRequired();
        builder.Property(i => i.ToLatitude).IsRequired();
        builder.Property(i => i.ToLongitude).IsRequired();
        builder.Property(i => i.VehicleType).IsRequired();
        builder.Property(i => i.RequestedFare).IsRequired();
    }
}