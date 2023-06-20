using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Notifications;

namespace Vculp.Api.Data.EntityFramework.Notifications.Configurations
{
    public class ContactConfiguration: EntityConfiguration<Contact>
    {
        public ContactConfiguration(CoreContext context)
            : base(context)
        {
        }
        protected override string SchemaName => "Notification";

        protected override string TableName => "Contacts";
        
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.ContactId)
                    .IsRequired();

            builder.Property(i => i.FirstName)
                   .IsRequired()
                   .HasMaxLength(120);

            builder.Property(i => i.LastName)
                   .IsRequired()
                   .HasMaxLength(120);

            builder.Property(c => c.MobileNumber)
                   .HasMaxLength(20);

            builder.Property(c => c.EmailAddress)
                   .HasMaxLength(254);

            builder.HasDiscriminator<string>("ContactType")
                   .HasValue<CustomerContact>("CustomerContact")
                   .HasValue<SalesRepContact>("SalesRepContact")
                   .HasValue<DriverContact>("DriverContact")
                   .HasValue<DeliverySiteContact>("DeliverySiteContact");

            builder.Property("ContactType")
                   .IsRequired()
                   .HasMaxLength(30);

        }

    }
}
