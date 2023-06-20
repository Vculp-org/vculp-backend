using System;
using Vculp.Api.Domain.Core.Rbac.Events;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.Rbac
{
    public class RolePermission : AggregateRoot, IAuditableEntity
    {
        /// <summary>
        /// Used by EF Core
        /// </summary>
        private RolePermission()
        {
        }

        public RolePermission(Role role, ApplicationPermission permission)
        {
            RoleId = role?.Id ?? throw new ArgumentNullException(nameof(role));
            ApplicationPermissionId = permission?.Id ?? throw new ArgumentNullException(nameof(permission));

            //Add Created Domain Event
            AddDomainEvent(new RolePermissionCreatedEvent(this));
        }

        public Guid RoleId { get; private set; }
        public Guid ApplicationPermissionId { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public int? CreatedByUserId { get; private set; }
        public string CreatedByUserName { get; private set; }
        public int? LastUpdatedByUserId { get; private set; }
        public string LastUpdatedByUserName { get; private set; }

        public void Delete()
        {
            //Add Deleted Domain Event
            AddDomainEvent(new RolePermissionDeletedEvent(this));
        }
    }
}
