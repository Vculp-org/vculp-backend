using System;
using Vculp.Api.Domain.Core.Rbac.Events;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.Rbac
{
    public class Role : AggregateRoot, IAuditableEntity
    {
        /// <summary>
        /// Used by EF Core
        /// </summary>
        private Role()
        {
        }

        public Role(
            string name,
            string description)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{nameof(name)} cannot be null, empty, or contain only whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException($"{nameof(description)} cannot be null, empty, or contain only whitespace.", nameof(description));
            }

            Name = name;
            Description = description;

            //Add Created Domain Event
            AddDomainEvent(new RoleCreatedEvent(this));
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public int? CreatedByUserId { get; private set; }
        public string CreatedByUserName { get; private set; }
        public int? LastUpdatedByUserId { get; private set; }
        public string LastUpdatedByUserName { get; private set; }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (Name != name)
            {
                Name = name;
                SetStateToUpdated();
            }
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (Description != description)
            {
                Description = description;
                SetStateToUpdated();
            }
        }

        public void Delete()
        {
            //Add Deleted Domain Event
            AddDomainEvent(new RoleDeletedEvent(this));
        }
    }
}
