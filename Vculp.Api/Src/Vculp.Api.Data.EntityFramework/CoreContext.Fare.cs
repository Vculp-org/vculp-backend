using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.FareRecommendation.Configurations;
using Vculp.Api.Data.EntityFramework.Vehicle.Configurations;

namespace Vculp.Api.Data.EntityFramework;

public partial class CoreContext : DbContext
{
    // Entities
    public DbSet<Domain.Core.FareRecommendation.FareRecommendationDetails> FareRecommendationDetails  { get; set; }

    // Configurations

    public void OnFareModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FareRecommendationDetailsConfiguration(this));
    }

}