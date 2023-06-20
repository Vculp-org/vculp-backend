﻿using System;
using Vculp.DDD.Shared;

namespace Vculp.Api.Domain.Core.Rbac.Events
{
    public class RolePermissionDeletedEvent : DomainEvent
    {
        /// <summary>
        /// Used for deserialization
        /// </summary>
        private RolePermissionDeletedEvent()
        {
        }

        public RolePermissionDeletedEvent(RolePermission rolePermission)
        {
            if (rolePermission == null)
            {
                throw new ArgumentNullException(nameof(rolePermission));
            }

            RolePermissionId = rolePermission.Id;
        }

        public Guid RolePermissionId { get; private set; }
    }
}