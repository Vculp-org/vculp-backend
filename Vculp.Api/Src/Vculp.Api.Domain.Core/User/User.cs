using System;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Domain.Core.User
{
    public class User : AggregateRoot
    {
        #region Constructors

        protected User()
        {
            State = ObjectState.Unchanged;
        }

        public User
        (
            int externalUserId,
            string firstName,
            string lastName,
            string email,
            string mobileNumber
        )
        {
            if (externalUserId < 1)
            {
                throw new ArgumentException($"{nameof(externalUserId)} cannot be less than one.", nameof(externalUserId));
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException($"{nameof(firstName)} cannot be an empty name", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException($"{nameof(lastName)} cannot be an empty name", nameof(lastName));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"{nameof(email)} cannot be an empty name", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                throw new ArgumentException($"{nameof(mobileNumber)} cannot be an empty name", nameof(mobileNumber));
            }

            ExternalUserId = externalUserId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            MobileNumber = mobileNumber;
            DisplayName = $"{FirstName.Trim()} {LastName.Trim()}";
            AddDomainEvent(new UserCreatedEvent(this));
        }

        #endregion


        #region Properties

        // TODO: This property should be removed once the Identity Server claims for user id as switched to Guids
        public int ExternalUserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string MobileNumber { get; private set; }
        public bool CanReceiveEmail => !string.IsNullOrWhiteSpace(EmailAddress);
        public bool CanReceiveSms => !string.IsNullOrWhiteSpace(MobileNumber);
        public string DisplayName { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdated { get; private set; }

        #endregion
        
    }
}