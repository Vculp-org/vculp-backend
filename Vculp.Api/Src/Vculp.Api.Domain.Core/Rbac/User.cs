using System;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.Rbac
{
    public class User : Entity,IAuditableEntity
    {
        /// <summary>
        /// Used by EF Core
        /// </summary>
        private User()
        {
        }

        public User(
            int externalUserId,
            string userName,
            string firstName,
            string lastName)
        {
            if (externalUserId < 1)
            {
                throw new ArgumentException($"{nameof(externalUserId)} cannot be less than one.", nameof(externalUserId));
            }

            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException($"{nameof(userName)} cannot be null, empty or contain only whitespace", nameof(userName));
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException($"{nameof(firstName)} cannot be null, empty or contain only whitespace", nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException($"{nameof(lastName)} cannot be null, empty or contain only whitespace", nameof(lastName));
            }

            ExternalUserId = externalUserId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            DisplayName = $"{FirstName.Trim()} {LastName.Trim()}";
        }

        // TODO: This property should be removed once the Identity Server claims for user id as switched to Guids
        public int ExternalUserId { get; private set; } 
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DisplayName { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public int? CreatedByUserId { get; private set; }
        public string CreatedByUserName { get; private set; }
        public int? LastUpdatedByUserId { get; private set; }
        public string LastUpdatedByUserName { get; private set; }
    }
}
