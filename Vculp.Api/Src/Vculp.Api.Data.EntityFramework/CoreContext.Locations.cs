using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Location.Configurations;
using Vculp.Api.Data.EntityFramework.Vehicle.Configurations;
using Vculp.Api.Domain.Core.Location;

namespace Vculp.Api.Data.EntityFramework;

public partial class CoreContext : DbContext
{
    // Entities
    public DbSet<FavoriteLocation> FavoriteLocations{ get; set; }

    // Configurations

    public void OnLocationsModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FavoriteLocationConfiguration(this));
    }
    
}