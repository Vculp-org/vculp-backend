using System;
using Vculp.Api.Domain.Core.Rbac.Events;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.Rbac
{
    public class RoleMember : AggregateRoot, IAuditableEntity
    {
        /// <summary>
        /// Used by EF Core
        /// </summary>
        private RoleMember()
        {
        }

        public RoleMember(Role role, User user)
        {
            RoleId = role?.Id ?? throw new ArgumentNullException(nameof(role));
            UserId = user?.Id ?? throw new ArgumentNullException(nameof(user));

            //Add Created Domain Event
            AddDomainEvent(new RoleMemberCreatedEvent(this));
        }

        public Guid RoleId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public int? CreatedByUserId { get; private set; }
        public string CreatedByUserName { get; private set; }
        public int? LastUpdatedByUserId { get; private set; }
        public string LastUpdatedByUserName { get; private set; }

        public void Delete()
        {
            //Add Deleted Domain Event
            AddDomainEvent(new RoleMemberDeletedEvent(this));
        }
    }
}
