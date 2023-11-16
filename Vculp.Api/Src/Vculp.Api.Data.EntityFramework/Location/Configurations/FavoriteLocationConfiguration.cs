using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Location;
using Vculp.Api.Domain.Core.Notifications;

namespace Vculp.Api.Data.EntityFramework.Location.Configurations;

public class FavoriteLocationConfiguration:ActivatableEntityConfiguration<FavoriteLocation>
{
    public FavoriteLocationConfiguration(CoreContext context) : base(context)
    {
    }

    protected override string SchemaName => "Location";

    protected override string TableName => "FavoriteLocations";
    
    public override void Configure(EntityTypeBuilder<FavoriteLocation> builder)
    {
        base.Configure(builder);

        builder.Property(i => i.Latitude)
            .IsRequired();

        builder.Property(i => i.Longitude)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(i => i.LocationType)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(i => i.UserId).IsRequired();

    }
}