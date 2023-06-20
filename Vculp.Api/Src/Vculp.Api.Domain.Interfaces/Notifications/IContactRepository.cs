using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.Notifications;
using Vculp.Api.Domain.Interfaces.Common;

namespace Vculp.Api.Domain.Interfaces.Notifications
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<Contact> GetByContactId(Guid contactId);
        Task<IEnumerable<Contact>> GetContactsById(IEnumerable<Guid> contactIds);
    }
}
