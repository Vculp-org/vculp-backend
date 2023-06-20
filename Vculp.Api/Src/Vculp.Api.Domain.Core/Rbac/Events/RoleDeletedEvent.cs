using System;
using Vculp.DDD.Shared;

namespace Vculp.Api.Domain.Core.Rbac.Events
{
    public class RoleDeletedEvent : DomainEvent
    {
        /// <summary>
        /// Used for deserialization
        /// </summary>
        private RoleDeletedEvent()
        {
        }

        public RoleDeletedEvent(Role role)
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