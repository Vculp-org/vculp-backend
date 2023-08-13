using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;

namespace Vculp.Api.Data.EntityFramework.Vehicle.Configurations;

public class VehicleConfigurations : EntityConfiguration<Domain.Core.Vehicle.Vehicle>
{
    public VehicleConfigurations(CoreContext context)
        : base(context)
    {
    }

    protected override string SchemaName => "Vehicle";

    protected override string TableName => "Vehicles";

    public override void Configure(EntityTypeBuilder<Domain.Core.Vehicle.Vehicle> builder)
    {
        base.Configure(builder);

        builder.Property(i => i.VehicleType)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(i => i.VehicleBodyType)
            .IsRequired()
            .HasMaxLength(120);

        // builder.OwnsMany(b1 => b1.FareDetails, b1 =>
        // {
        //     b1.Ignore(pr => pr.State);
        //
        //     b1.Property(fd => fd.City)
        //         .HasColumnName("City")
        //         .HasMaxLength(200)
        //         .IsRequired();
        //
        //     b1.Property(pr => pr.VehicleId)
        //         .HasColumnName("VehicleId")
        //         .IsRequired();
        //
        //     b1.Property(pr => pr.BaseFare)
        //         .HasColumnName("BaseFare")
        //         .IsRequired();
        //
        //     b1.Property(pr => pr.FreeKms)
        //         .HasColumnName("FreeKms")
        //         .IsRequired();
        //
        //     b1.Property(pr => pr.PerKmFare)
        //         .HasColumnName("PerKmFare")
        //         .IsRequired();
        //
        //     b1.Property(pr => pr.MinPerKmFare)
        //         .HasColumnName("MinPerKmFare")
        //         .IsRequired();
        //
        //     b1.Property(pr => pr.PerMinuteFare)
        //         .HasColumnName("PerMinuteFare")
        //         .IsRequired();
        //
        //     b1.Property(pr => pr.CancellationFeePercentage)
        //         .HasColumnName("CancellationFeePercentage")
        //         .IsRequired();
        //
        //     b1.Property(pr => pr.CancellationMaxAmount)
        //         .HasColumnName("CancellationMaxAmount")
        //         .IsRequired();
        // });
        //
        // builder.Navigation(s => s.FareDetails).IsRequired();
        
        builder.OwnsMany(i => i.FareDetails, b =>
        {
            b.ToTable("FareDetails", "Vehicle");

            b.WithOwner().HasForeignKey(x => x.VehicleId);

            b.Property<int>("ClusterId")
                .UseIdentityColumn();

            b.HasIndex("ClusterId")
                .IsUnique()
                .IsClustered();

            b.Property<int>("ClusterId")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            
            b.HasKey("VehicleId", "ClusterId", "City")
                .IsClustered(false);

            b.Ignore(i => i.State);

        }).UsePropertyAccessMode(PropertyAccessMode.Field);

    }
}