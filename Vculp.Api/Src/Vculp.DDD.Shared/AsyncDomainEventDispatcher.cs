using Vculp.DDD.Shared.Interfaces;

namespace Vculp.DDD.Shared
{
    public sealed class AsyncDomainEventDispatcher : EventDispatcher, IAsyncDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public override Type HandlerType => typeof(IAsyncDomainEventHandler<>);

        public override string HandlerMethodName => "HandleAsync";

        public AsyncDomainEventDispatcher(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException("serviceProvider");
        }
    }
}

