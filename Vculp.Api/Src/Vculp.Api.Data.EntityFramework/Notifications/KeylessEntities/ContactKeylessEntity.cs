using System;
using Vculp.Api.Data.EntityFramework.Common;

namespace Vculp.Api.Data.EntityFramework.Notifications.KeylessEntities
{

    public class ContactKeyLessEntity : KeylessEntity<ContactKeyLessEntity>
    {
        public Guid ContactId { get; set; }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContactType { get; set; }
    }
}