using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.Notifications;

namespace Vculp.Api.Domain.Interfaces.Notifications
{
    public interface ICustomerContactRepository
    {
        Task<CustomerContact> GetByContactIdAsync(Guid contactId);
        Task<IEnumerable<CustomerContact>> GetByContactIdsAsync(IEnumerable<Guid> contactIds);
        Task<IEnumerable<CustomerContact>> GetByCustomerIdAsync(Guid customerId);
    }
}
