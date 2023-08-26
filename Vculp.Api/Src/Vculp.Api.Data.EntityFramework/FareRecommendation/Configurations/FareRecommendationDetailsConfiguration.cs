using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.FareRecommendation;

namespace Vculp.Api.Data.EntityFramework.FareRecommendation.Configurations;

public class FareRecommendationDetailsConfiguration: EntityConfiguration<FareRecommendationDetails>
{
    public FareRecommendationDetailsConfiguration(CoreContext context) : base(context)
    {
    }
    
    protected override string SchemaName => "Fare";

    protected override string TableName => "FareRecommendationDetails";
    
    public override void Configure(EntityTypeBuilder<FareRecommendationDetails> builder)
    {
        base.Configure(builder);

        builder.Property(r => r.Origin)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(r => r.Destination)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(r => r.Distance)
            .IsRequired();
        
        builder.Property(r => r.Duration)
            .IsRequired();
        
        builder.Property(r => r.BaseFare)
            .IsRequired();
        
        builder.Property(r => r.DurationFare)
            .IsRequired();
        builder.Property(r => r.TollCharges)
            .IsRequired();
        builder.Property(r => r.MinimumDistanceFare)
            .IsRequired();
        builder.Property(r => r.RecommendedDistanceFare)
            .IsRequired();
        builder.Property(r => r.VehicleTypeId)
            .IsRequired();
        builder.Property(r => r.BaseFareFreeKms)
            .IsRequired();
        builder.Property(r => r.ActualDistanceAfterFreeKms)
            .IsRequired();
        builder.Property(r => r.UserId)
            .IsRequired();
    }
    
}