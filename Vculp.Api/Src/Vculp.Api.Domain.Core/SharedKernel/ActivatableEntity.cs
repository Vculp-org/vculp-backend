using System;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.SharedKernel
{
    public abstract class ActivatableEntity : AggregateRoot, IAuditableEntity
    {
        public bool IsActive { get; private set; }
        public DateTime CreationTime { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public int? CreatedByUserId { get; private set; }
        public string CreatedByUserName { get; private set; }
        public int? LastUpdatedByUserId { get; private set; }
        public string LastUpdatedByUserName { get; private set; }
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
    }
}
