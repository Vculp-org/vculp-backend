using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.Notifications;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.Notifications
{
    public interface IDeliverySiteContactRepository : IRepository<DeliverySiteContact>
    {
        Task<IEnumerable<DeliverySiteContact>> GetAllBySiteIdAsync(Guid deliverySiteId);
        Task<DeliverySiteContact> GetByContactIdAsync(Guid contactId);
    }
}
