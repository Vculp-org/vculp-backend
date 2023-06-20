using System;
using Vculp.DDD.Shared;

namespace Vculp.Api.Domain.Core.Rbac.Events
{
    public class RoleMemberDeletedEvent : DomainEvent
    {
        /// <summary>
        /// Used for deserialization
        /// </summary>
        private RoleMemberDeletedEvent()
        {
        }

        public RoleMemberDeletedEvent(RoleMember roleMember)
        {
            if (roleMember == null)
            {
                throw new ArgumentNullException(nameof(roleMember));
            }

            RoleMemberId = roleMember.Id;   
        }

        public Guid RoleMemberId { get; private set; }
    }
}