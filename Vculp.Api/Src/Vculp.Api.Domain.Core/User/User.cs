using System;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.User
{
    public class User : AggregateRoot, ICreationAuditable, IUpdateAuditable
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

            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                throw new ArgumentException($"{nameof(mobileNumber)} cannot be an empty name", nameof(mobileNumber));
            }

            ExternalUserId = externalUserId;
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
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
        public DateTime CreationTime { get; private set; }
        public int? CreatedByUserId { get; }
        public string CreatedByUserName { get; }
        public DateTime LastUpdated { get; private set; }
        public int? LastUpdatedByUserId { get; }
        public string LastUpdatedByUserName { get; }
        public bool IsActive { get; private set; }
        public DateTime? DateOfBirth { get; private set; }

        #endregion



        #region Methods

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"{nameof(email)} cannot be an empty name", nameof(email));
            }

            EmailAddress = email;
        }

        public void ChangeDateOfBirth(DateTime dateTime)
        {
            DateOfBirth = dateTime;
            SetStateToUpdated();
        }

        public void ChangeFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException($"{nameof(firstName)} cannot be an empty name", nameof(firstName));
            }

            FirstName = firstName;
            SetStateToUpdated();
        }

        public void ChangeLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException($"{nameof(lastName)} cannot be an empty name", nameof(lastName));
            }

            LastName = lastName;
            SetStateToUpdated();
        }
        
        public void Activate()
        {
            if (!IsActive)
            {
                IsActive = true;
                SetStateToUpdated();
            }
        }

        public void Deactivate()
        {
            if (IsActive)
            {
                IsActive = false;
                SetStateToUpdated();
            }
        }
        
        #endregion
        
    }
}