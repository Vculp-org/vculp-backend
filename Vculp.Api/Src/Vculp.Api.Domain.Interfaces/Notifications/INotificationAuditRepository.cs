using System.Collections.Generic;
using Vculp.Api.Domain.Core.Notifications;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.Notifications
{
    public interface INotificationAuditRepository:IRepository<NotificationAudit>
    {
        void AddNotificationAudit(NotificationAudit audit, List<NotificationAuditContact> auditContacts);
    }
}
