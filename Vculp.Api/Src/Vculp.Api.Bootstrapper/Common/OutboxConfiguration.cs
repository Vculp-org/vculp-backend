using System;
using System.Threading.Channels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vculp.TransactionalOutbox.Triggers;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class OutboxConfiguration
    {
        public static void ConfigureOutbox(this IServiceCollection services, Action<IServiceCollection> outboxTriggerProcessorSetupAction)
        {
            if (outboxTriggerProcessorSetupAction == null)
            {
                throw new ArgumentNullException(nameof(outboxTriggerProcessorSetupAction));
            }

            services.AddSingleton<OutboxProcessingTriggerChannel>(services =>
            {
                var logger = services.GetService<ILogger<OutboxProcessingTriggerChannel>>();
                return new OutboxProcessingTriggerChannel(
                    new BoundedChannelOptions(10)
                    {
                        SingleReader = true
                    },
                    logger);
            });

            services.AddTransient<IOutboxProcessingTrigger>(services =>
            {
                return services.GetService<OutboxProcessingTriggerChannel>();
            });

            outboxTriggerProcessorSetupAction.Invoke(services);
        }
    }
}