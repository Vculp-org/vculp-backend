using System;

namespace Vculp.Api.Domain.Core.Notifications
{
    public interface ICustomerContact : IContact
    {
        Guid CustomerId { get; }
    }
}
