using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.FavoriteRegion.Configurations;
using Vculp.Api.Data.EntityFramework.User.Configurations;

namespace Vculp.Api.Data.EntityFramework
{
    public partial class CoreContext : DbContext
    {
        public DbSet<Domain.Core.FavoriteRegion.FavoriteRegion> FavoriteRegions { get; set; }

        public void OnFavoriteRegionModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FavoriteRegionConfiguration(this));
        }
    }
}
