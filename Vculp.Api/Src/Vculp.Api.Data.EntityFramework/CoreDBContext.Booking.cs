using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Booking.Configurations;
using Vculp.Api.Data.EntityFramework.User.Configurations;
using Vculp.Api.Domain.Core.Booking;

namespace Vculp.Api.Data.EntityFramework;

public partial class CoreContext : DbContext
{
    public DbSet<Ride> Rides { get; set; }

    public void OnRideModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RideConfiguration(this));
    }
}