using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vculp.Api
{
    public static class BroadcastHandlingConfiguration
    {
        public static void ConfigureBroadcastHandling(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            // services.AddMediatR(typeof(BroadcastHandler<>));
            //
            // services.AddHostedService<AzureServiceBusBroadcastReceiverService>(serviceFactory =>
            // {
            //     var logger = serviceFactory.GetRequiredService<ILogger<AzureServiceBusBroadcastReceiverService>>();
            //     var serviceProvider = serviceFactory.GetRequiredService<IServiceProvider>();
            //
            //     return new AzureServiceBusBroadcastReceiverService(
            //         new QueueClient(
            //             configuration["serviceBus:connectionString"],
            //             configuration["serviceBus:broadcastsQueueName"]),
            //         logger,
            //         serviceProvider);
            // });
        }
    }
}