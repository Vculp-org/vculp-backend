using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.Notifications;

namespace Vculp.Api.Data.EntityFramework.Notifications.Configurations
{
    public class NotificationAuditConfiguration : EntityConfiguration<NotificationAudit>
    {
        public NotificationAuditConfiguration(CoreContext context)
            : base(context)
        {
        }
        protected override string SchemaName => "Notification";

        protected override string TableName => "NotificationAudits";
        public override void Configure(EntityTypeBuilder<NotificationAudit> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.UserId)
                    .IsRequired();

            builder.Property(i => i.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(i => i.Message)
                   .IsRequired();

            builder.Property(c => c.NotificationType)
                   .IsRequired();

            builder.Property(c => c.Date)
                   .IsRequired();
        }
    }
}
