using System;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.Rbac
{
    public class ApplicationPermission : Entity, IAuditableEntity
    {
        /// <summary>
        /// Used by EF Core
        /// </summary>
        private ApplicationPermission()
        {
        }

        public ApplicationPermission(
            string permissionKey,
            string displayName,
            string description)
        {
            if (string.IsNullOrWhiteSpace(permissionKey))
            {
                throw new ArgumentException($"{nameof(permissionKey)} cannot be null, empty or contain only whitespace", nameof(permissionKey));
            }

            if (string.IsNullOrWhiteSpace(displayName))
            {
                throw new ArgumentException($"{nameof(displayName)} cannot be null, empty or contain only whitespace", nameof(displayName));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException($"{nameof(description)} cannot be null, empty or contain only whitespace", nameof(description));
            }

            PermissionKey = permissionKey;
            DisplayName = displayName;
            Description = description;
        }

        public string PermissionKey { get; private set; }
        public string DisplayName { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public int? CreatedByUserId { get; private set; }
        public string CreatedByUserName { get; private set; }
        public int? LastUpdatedByUserId { get; private set; }
        public string LastUpdatedByUserName { get; private set; }
    }
}
