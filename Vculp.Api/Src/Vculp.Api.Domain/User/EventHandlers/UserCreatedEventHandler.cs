using System.Threading.Tasks;
using Vculp.Api.Domain.Core.User;
using Vculp.DDD.Shared.Interfaces;

namespace Vculp.Api.Domain.User.EventHandlers;

public class UserCreatedEventHandler: ITransactionalDomainEventHandler<UserCreatedEvent>
{
    public Task HandleAsync(UserCreatedEvent domainEvent)
    {
        throw new System.NotImplementedException();
    }
}