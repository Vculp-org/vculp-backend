using System;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Domain.Core.Notifications
{
    public class NotificationAuditContact : Entity
    {
        #region Constructors

        protected NotificationAuditContact()
        {
            State = ObjectState.Unchanged;
        }

        public NotificationAuditContact
        (
            Guid contactId,
            string firstName,
            string lastName,
            string customerCode,
            string customerName,
            string mobileNumber,
            string emailAddress,
            NotificationAudit audit
        )
        {
            ContactId = contactId;
            FirstName = firstName;
            LastName = lastName;
            CustomerCode = customerCode;
            CustomerName = customerName;
            MobileNumber = mobileNumber;
            EmaiAddress = emailAddress;
            NotificationAudit = audit;
        }
        #endregion

        #region Properties

        public Guid ContactId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CustomerCode { get; private set; }
        public string CustomerName { get; private set; }
        public string MobileNumber { get; private set; }
        public string EmaiAddress { get; private set; }
        public NotificationAudit NotificationAudit { get; private set; }

        #endregion
    }
}
