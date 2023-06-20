using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vculp.Api.Data.EntityFramework.Common.Configurations;
using Vculp.Api.Data.EntityFramework.Notifications.KeylessEntities;

namespace Vculp.Api.Data.EntityFramework.Notifications.Configurations
{
    public class ContactKeyLessEntityConfiguration : KeylessEntityConfiguration<ContactKeyLessEntity>
    {
        public ContactKeyLessEntityConfiguration(CoreContext context) : base(context)
        {
        }

        public override void Configure(EntityTypeBuilder<ContactKeyLessEntity> builder)
        {
            builder.HasNoKey();

            builder.ToSqlQuery(@"SELECT
                                 ContactId,
                                 CustomerId,
                                 FirstName,
                                 LastName,
                                 MobileNumber,
                                 EmailAddress,
                                 ContactType 
                                FROM [Notification].[Contacts] 
                                WHERE IsDeleted <> 1 AND (DeliverySiteActive IS NULL OR DeliverySiteActive = 1)");
        }
    }
}