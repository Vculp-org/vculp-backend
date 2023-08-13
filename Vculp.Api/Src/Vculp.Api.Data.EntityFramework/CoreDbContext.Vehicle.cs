using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Notifications.Configurations;
using Vculp.Api.Data.EntityFramework.Vehicle.Configurations;

namespace Vculp.Api.Data.EntityFramework;

public partial class CoreContext : DbContext
{
    // Entities
    public DbSet<Domain.Core.Vehicle.VehicleType> VehicleTypes { get; set; }

    // Configurations

    public void OnVehiclesModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VehicleTypeConfigurations(this));
    }

}