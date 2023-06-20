using System;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.User;
using Vculp.DDD.Shared.Interfaces;

namespace Vculp.Api.Domain.Notifications.EventHandlers.DomainEvents
{
    public class CustomerCreatedEventHandler : ITransactionalDomainEventHandler<UserCreatedEvent>
    {
        public Task HandleAsync(UserCreatedEvent domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
