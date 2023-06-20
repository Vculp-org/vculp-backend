using System;
using Vculp.Api.Domain.Core.SharedKernel;
using static Vculp.Api.Domain.Core.Notifications.NotificationEnum;

namespace Vculp.Api.Domain.Core.Notifications
{
    public class NotificationAudit : Entity
    {
        #region Constructors

        protected NotificationAudit()
        {
            State = ObjectState.Unchanged;
        }

        public NotificationAudit(
            int userId,
            string name,
            string message,
            NotificationType notificationType,
            DateTime date)
        {
            UserId = userId;
            Name = name;
            Message = message;
            NotificationType = notificationType;
            Date = date;
        }
        #endregion
        
        #region Properties

        public int UserId { get; private set; }
        public string Name { get; private set; }
        public string Message { get; private set; }
        public NotificationType NotificationType { get; private set; }
        public DateTime Date { get; private set; }

        #endregion
    }
}