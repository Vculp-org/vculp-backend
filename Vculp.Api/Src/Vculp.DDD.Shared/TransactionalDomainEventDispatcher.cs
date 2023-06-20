using Vculp.DDD.Shared.Interfaces;

namespace Vculp.DDD.Shared;

public sealed class TransactionalDomainEventDispatcher : EventDispatcher, ITransactionalDomainEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public override Type HandlerType => typeof(ITransactionalDomainEventHandler<>);

    public override string HandlerMethodName => "HandleAsync";

    public TransactionalDomainEventDispatcher (IServiceProvider serviceProvider)
        : base (serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException ("serviceProvider");
    }
}
