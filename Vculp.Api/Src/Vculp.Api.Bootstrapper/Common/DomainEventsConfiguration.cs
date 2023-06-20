using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Domain.Core.SharedKernel.EventReduction;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;
using Vculp.Api.Domain.Notifications.EventHandlers.DomainEvents;
using Vculp.DDD.Shared;
using Vculp.DDD.Shared.Interfaces;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class DomainEventsConfiguration
    {
        public static void AddDomainEventComponents(this IServiceCollection services, bool registerAsyncHandlers = true)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<CustomerCreatedEventHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(ITransactionalDomainEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            if (registerAsyncHandlers)
            {
                services.Scan(scan => scan
                    .FromAssemblyOf<CustomerCreatedEventHandler>()
                    .AddClasses(classes => classes.AssignableTo(typeof(IAsyncDomainEventHandler<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
            }

            //services.AddTransient<IDomainEventReducer, TempDomainEventReductionProcessor>();
            services.AddTransient<ITransactionalDomainEventDispatcher, TransactionalDomainEventDispatcher>();
            services.AddTransient<IAsyncDomainEventDispatcher, AsyncDomainEventDispatcher>();

            services.Scan(scan => scan
                    .FromAssemblyOf<IAuditableEntity>()
                    .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventReducer<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());
        }
    }
}
