using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;

namespace Vculp.Api.Data.EntityFramework.Vehicle.Configurations;

public class VehicleTypeConfigurations : EntityConfiguration<Domain.Core.Vehicle.VehicleType>
{
    public VehicleTypeConfigurations(CoreContext context)
        : base(context)
    {
    }

    protected override string SchemaName => "Vehicle";

    protected override string TableName => "VehicleTypes";

    public override void Configure(EntityTypeBuilder<Domain.Core.Vehicle.VehicleType> builder)
    {
        base.Configure(builder);

        builder.Property(i => i.Type)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(i => i.BodyType)
            .IsRequired()
            .HasMaxLength(120);
        
        builder.OwnsMany(i => i.FareDetails, b =>
        {
            b.ToTable("FareDetails", "Vehicle");

            b.WithOwner().HasForeignKey(x => x.VehicleTypeId);

            b.Property<int>("ClusterId")
                .UseIdentityColumn();

            b.HasIndex("ClusterId")
                .IsUnique()
                .IsClustered();

            b.Property<int>("ClusterId")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            
            b.HasKey("VehicleTypeId", "ClusterId", "City")
                .IsClustered(false);

            b.Ignore(i => i.State);

        }).UsePropertyAccessMode(PropertyAccessMode.Field);

    }
}