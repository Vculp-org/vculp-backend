using System;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Domain.Core.Notifications
{
    public abstract class Contact : Entity
    {
        #region Constructors

        protected Contact()
        {
            State = ObjectState.Unchanged;
        }
        public Contact
        (
            Guid contactId,
            string firstName,
            string lastName
        )
        {
            if (contactId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(contactId)} cannot be an empty guid", nameof(contactId));
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException($"{nameof(firstName)} cannot be an empty name", nameof(firstName));
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException($"{nameof(lastName)} cannot be an empty name", nameof(lastName));
            }

            ContactId = contactId;
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion

        #region Properties
        public Guid ContactId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string MobileNumber { get; private set; }
        public bool CanReceiveEmail 
        {
            get {return !string.IsNullOrWhiteSpace(EmailAddress);}
        }
        public bool CanReceiveSms
        {
            get
            {return !string.IsNullOrWhiteSpace(MobileNumber);}
        }
        #endregion


        #region Methods
        public void ChangeFirstname(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException($"{nameof(firstName)} is null, empty or contains only whitespace", nameof(firstName));
            }
            FirstName = firstName;
            SetStateToUpdated();
        }

        public void ChangeLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException($"{nameof(lastName)} is null, empty or contains only whitespace", nameof(lastName));
            }
            LastName = lastName;
            SetStateToUpdated();
        }
        public void ChangeEmailAddress(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentException($"{nameof(emailAddress)} is null, empty or contains only whitespace", nameof(emailAddress));
            }
            EmailAddress = emailAddress;
            SetStateToUpdated();
        }

        public void ChangeMobileNumber(string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                throw new ArgumentException($"{nameof(mobileNumber)} is null, empty or contains only whitespace", nameof(mobileNumber));
            }
            MobileNumber = mobileNumber;
            SetStateToUpdated();
        }

        public void ClearEmailAddress()
        {
            EmailAddress = null;
            SetStateToUpdated();
        }

        public void ClearMobileNumber()
        {
            MobileNumber = null;
            SetStateToUpdated();
        }
        #endregion
    }
}
