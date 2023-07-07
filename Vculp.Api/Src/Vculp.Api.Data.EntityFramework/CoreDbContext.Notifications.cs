using Microsoft.EntityFrameworkCore;
using Vculp.Api.Data.EntityFramework.Notifications.Configurations;

namespace Vculp.Api.Data.EntityFramework
{
    public partial class CoreContext : DbContext
    {
        // Entities
        
        // Configurations

        public void OnNotificationsModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration(this));
            modelBuilder.ApplyConfiguration(new NotificationAuditConfiguration(this));
            modelBuilder.ApplyConfiguration(new NotificationAuditContactConfiguration(this));
            modelBuilder.ApplyConfiguration(new ContactKeyLessEntityConfiguration(this));
            modelBuilder.ApplyConfiguration(new DeliverySiteContactConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerContactConfiguration());
        }

    }
}
