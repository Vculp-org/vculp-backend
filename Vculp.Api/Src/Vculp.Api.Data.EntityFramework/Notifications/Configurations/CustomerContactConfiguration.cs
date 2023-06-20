using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Domain.Core.Notifications;

namespace Vculp.Api.Data.EntityFramework.Notifications.Configurations
{
    public class CustomerContactConfiguration : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> builder)
        {
            builder.HasBaseType<Contact>();

            builder.Property(c => c.CustomerId)
                   .HasColumnName("CustomerId");
        }
    }
}
