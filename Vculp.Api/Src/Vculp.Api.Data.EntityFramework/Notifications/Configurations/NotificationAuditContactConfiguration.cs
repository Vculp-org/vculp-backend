using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Notifications;

namespace Vculp.Api.Data.EntityFramework.Notifications.Configurations
{
    public class NotificationAuditContactConfiguration: EntityConfiguration<NotificationAuditContact>
    {
        public NotificationAuditContactConfiguration(CoreContext context)
            : base(context)
        {
        }
        protected override string SchemaName => "Notification";

        protected override string TableName => "NotificationAuditContacts";
        public override void Configure(EntityTypeBuilder<NotificationAuditContact> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.ContactId)
                    .IsRequired();

            builder.Property(i => i.FirstName)
                   .HasMaxLength(120)
                   .IsRequired();

            builder.Property(i => i.LastName)
                   .HasMaxLength(120)
                   .IsRequired();

            builder.Property(c => c.CustomerCode)
                   .IsRequired();

            builder.Property(c => c.CustomerName)
                   .HasMaxLength(240)
                   .IsRequired();

            builder.HasOne(c => c.NotificationAudit)
                 .WithMany()
                 .IsRequired(true);

            builder.HasIndex("NotificationAuditId")
                   .HasDatabaseName($"IX_{TableName}_NotificationAuditId");
        }
    }
}
