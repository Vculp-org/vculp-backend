using CorrelationId.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Outbox;
using Vculp.Api.Data.EntityFramework;
using Vculp.Api.Data.EntityFramework.Common.UnitOfWork;
using Vculp.Api.Domain.Core.SharedKernel.EventReduction;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.DDD.Shared.Interfaces;
using Vculp.TransactionalOutbox.Triggers;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class UnitOfWorkConfiguration
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork>(serviceProvider =>
            {
                var crmContext = serviceProvider.GetRequiredService<CoreContext>();
                return new CommitChangesUnitOfWork(crmContext);
            });

            services.Decorate<IUnitOfWork>((inner, services) =>
            {
                var context = services.GetRequiredService<CoreContext>();
                var correlationContextAccessor = services.GetRequiredService<ICorrelationContextAccessor>();
                return new CorrelatableEntityPopulatingUnitOfWork(context, correlationContextAccessor, inner);
            });

            // services.Decorate<IUnitOfWork>((inner, services) =>
            // {
            //     var crmContext = services.GetRequiredService<CoreContext>();
            //     var eventDispatcher = services.GetRequiredService<ITransactionalDomainEventDispatcher>();
            //     var eventReducer = services.GetRequiredService<IDomainEventReducer>();
            //     return new EventProcessingUnitOfWork(crmContext, eventDispatcher, eventReducer, inner);
            // });

            // services.Decorate<IUnitOfWork>((inner, services) =>
            // {
            //     var crmContext = services.GetRequiredService<CoreContext>();
            //     var messageContext = services.GetRequiredService<MessageContext>();
            //     var outboxRepository = services.GetRequiredService<IOutboxMessageRepository>();
            //     return new ProcessManagerCommandDispatchingUnitOfWork(crmContext, messageContext, outboxRepository, inner);
            // });

            // Temporarily disabled the outbox processing trigger unit of work. This can be restored
            // when we have removed all database generated values and can dispatch messages with a single
            // commit approach.
            

            // services.Decorate<IUnitOfWork>((inner, services) =>
            // {
            //     var crmContext = services.GetRequiredService<CoreContext>();
            //     var outboxProcessingTrigger = services.GetRequiredService<IOutboxProcessingTrigger>();
            //     return new TransactionWrappingUnitOfWork(crmContext, outboxProcessingTrigger, inner);
            // });
        }
    }
}
