using System;

namespace Vculp.Api.Domain.Core.Notifications
{
    public class DeliverySiteContact : Contact, ICustomerContact
    {
        #region Constructors
        private DeliverySiteContact() : base()
        {

        }

        public DeliverySiteContact(Guid contactId, string firstName, string lastName, Guid customerId, Guid deliverySiteId)
            : base(contactId, firstName, lastName)
        {

            if (customerId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(customerId)} cannot be an empty guid.", nameof(customerId));
            }

            if (deliverySiteId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(deliverySiteId)} cannot be an empty guid.", nameof(deliverySiteId));
            }

            CustomerId = customerId;
            DeliverySiteId = deliverySiteId;
            ReceivesDeliveryTexts = false;
            DeliverySiteActive = false;
            EnabledForNotifications = false;
        }

        #endregion

        #region Properties
        public Guid CustomerId { get; private set; }
        public Guid DeliverySiteId { get; private set; }
        public bool ReceivesDeliveryTexts { get; private set; }
        public bool DeliverySiteActive { get; private set; }
        public bool EnabledForNotifications { get; private set; }

        #endregion

        #region Methods
        public void ChangeReceivesDeliveryTexts(bool receivesDeliveryTexts)
        {
            if (ReceivesDeliveryTexts == receivesDeliveryTexts)
            {
                return;
            }

            ReceivesDeliveryTexts = receivesDeliveryTexts;
            SetStateToUpdated();
        }
        public void ChangeDeliverySiteActive(bool deliverySiteActive)
        {
            if (DeliverySiteActive == deliverySiteActive)
            {
                return;
            }
            
            DeliverySiteActive = deliverySiteActive;
            SetStateToUpdated();
        }
        public void ChangeEnabledForNotification(bool enabledForNotifications)
        {
            if (EnabledForNotifications == enabledForNotifications)
            {
                return;
            }

            EnabledForNotifications = enabledForNotifications;
            SetStateToUpdated();
        }
        #endregion
    }

}
