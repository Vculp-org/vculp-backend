using System;
using Autofac;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Extensions.Configuration;
using Vculp.Api.Common.CommandBus;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Outbox;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class CommandBusConfiguration
    {
        private const string _commandBusSenderName = "commandBusSender";

        public static void ConfigureCommandBus(this ContainerBuilder builder, IConfiguration configuration, CommandBusDispatchMode dispatchMode)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (dispatchMode == CommandBusDispatchMode.ServiceBus)
            {
                builder.Register<ISenderClient>(c =>
                            new QueueClient(
                            configuration["serviceBus:connectionString"],
                            configuration["serviceBus:commandsQueueName"]))
                       .Named<ISenderClient>(_commandBusSenderName)
                       .SingleInstance();

                builder.Register<ICommandBus>(c =>
                {
                    var senderClient = c.ResolveNamed<ISenderClient>(_commandBusSenderName);
                    var messageContext = c.Resolve<MessageContext>();
                    return new AzureServiceBusCommandBusSender(senderClient, messageContext);
                });
            }
            else
            {
                builder.Register<ICommandBus>(c =>
                {
                    var outboxRepository = c.Resolve<IOutboxMessageRepository>();
                    var messageContext = c.Resolve<MessageContext>();
                    return new OutboxCommandBusSender(outboxRepository, messageContext);
                });
            }

            builder.RegisterDecorator<CommandValidatingCommandBus, ICommandBus>();
            builder.RegisterDecorator<LoggingCommandBus, ICommandBus>();
        }
    }

    public enum CommandBusDispatchMode
    {
        ServiceBus,
        Outbox
    }
}
