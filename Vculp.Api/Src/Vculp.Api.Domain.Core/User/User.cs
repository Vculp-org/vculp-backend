using System;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Domain.Core.User
{
    public abstract class User : Entity
    {
        #region Constructors

        protected User()
        {
            State = ObjectState.Unchanged;
        }

        public User
        (
            string firstName,
            string lastName,
            string email,
            string mobileNumber
        )
        {
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

            FirstName = firstName;
            LastName = lastName;
            EmailAddress = email;
            MobileNumber = mobileNumber;
        }

        #endregion


        #region Properties

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string MobileNumber { get; private set; }
        public bool CanReceiveEmail => !string.IsNullOrWhiteSpace(EmailAddress);
        public bool CanReceiveSms => !string.IsNullOrWhiteSpace(MobileNumber);

        #endregion
    }
}