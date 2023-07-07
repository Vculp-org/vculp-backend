using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.User.Configurations;

namespace Vculp.Api.Data.EntityFramework
{
    public partial class CoreContext : DbContext
    {
        public DbSet<Domain.Core.User.User> Users { get; set; }

        public void OnUserModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration(this));
        }
    }
}
