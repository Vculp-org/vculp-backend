using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Vculp.TransactionalOutbox.Models;
using Vculp.TransactionalOutbox.Routing;

namespace Vculp.TransactionalOutbox.Dispatch;

public class ServiceProviderOutboxMessageDispatcher : IOutboxMessageDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceProviderOutboxMessageDispatcher (IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException ("serviceProvider");
    }

    public async Task DispatchMessageAsync (OutboxMessage message)
    {
        if (message == null) {
            return;
        }
        Type type = message.GetType ();
        Type serviceType = typeof(IOutboxMessageRouter<>)!.MakeGenericType (type);
        IEnumerable<object> services = _serviceProvider.GetServices (serviceType);
        if (services == null) {
            return;
        }
        List<Task> list = new List<Task> ();
        foreach (object item2 in services) {
            Task item = (Task)item2.GetType ().GetTypeInfo ().GetMethod ("RouteMessageAsync")!.Invoke (item2, new object[1] { message });
            list.Add (item);
        }
        await Task.WhenAll (list);
    }
}