using System;
using Vculp.DDD.Shared;

namespace Vculp.Api.Domain.Core.Rbac.Events
{
    public class RoleCreatedEvent : DomainEvent
    {
        /// <summary>
        /// Used for deserialization
        /// </summary>
        private RoleCreatedEvent()
        {
        }

        public RoleCreatedEvent(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            RoleId = role.Id;
        }

        public Guid RoleId { get; private set; }
    }
}