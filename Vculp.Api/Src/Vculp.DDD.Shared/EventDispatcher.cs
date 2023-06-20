using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Vculp.DDD.Shared;

public abstract class EventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public abstract Type HandlerType { get; }

    public abstract string HandlerMethodName { get; }

    public EventDispatcher (IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException ("serviceProvider");
    }

    public async Task DispatchAsync (IEnumerable<IDomainEvent> events)
    {
        if (events == null) {
            return;
        }
        new List<Task> ();
        foreach (IDomainEvent domainEvent in events) {
            Type eventType = domainEvent.GetType ();
            Type serviceType = HandlerType.MakeGenericType (eventType);
            IEnumerable<object> services = _serviceProvider.GetServices (serviceType);
            if (services == null) {
                continue;
            }
            foreach (object item in services) {
                await (Task)item.GetType ().GetTypeInfo ().GetMethod (HandlerMethodName, new Type[1] { eventType })!.Invoke (item, new object[1] { domainEvent });
            }
        }
    }
}
