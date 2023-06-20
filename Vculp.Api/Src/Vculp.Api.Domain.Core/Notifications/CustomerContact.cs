using System;
using static Vculp.Api.Domain.Core.Notifications.CustomerContactTypeEnum;

namespace Vculp.Api.Domain.Core.Notifications
{
    public class CustomerContact : Contact, ICustomerContact
    {
        #region Constructors
        private CustomerContact() : base()
        {

        }

        public CustomerContact(
            Guid contactId,
            string firstName,
            string lastName,
            Guid customerId,
            CustomerContactType customerContactType)
            : base(contactId, firstName, lastName)
        {

            if (customerId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(customerId)} cannot be an empty guid.", nameof(customerId));
            }
           
            CustomerId = customerId;
            CustomerContactType = customerContactType;
        }

        #endregion

        #region Properties
        public Guid CustomerId { get; private set; }
        public CustomerContactType CustomerContactType { get; private set; }
        public bool EnabledForNotifications { get; private set; }
        #endregion

        #region Methods
        public void ChangeEnabledForNotification(bool enabledForNotifications)
        {
            EnabledForNotifications = enabledForNotifications;
            SetStateToUpdated();
        }

        #endregion
    }
}
