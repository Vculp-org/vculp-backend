using System;

namespace Vculp.Api.Domain.Core.Notifications
{
    public class SalesRepContact : Contact
    {
        #region Constructors
        private SalesRepContact() : base()
        {

        }

        public SalesRepContact(Guid contactId, string firstName, string lastName)
            : base(contactId, firstName, lastName)
        {
        }

        #endregion
    }
}
