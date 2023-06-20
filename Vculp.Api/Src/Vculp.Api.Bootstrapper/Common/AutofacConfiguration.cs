using System;
using Autofac;
using Microsoft.Extensions.Configuration;
using Vculp.Api.Domain.Core.SharedKernel.EventReduction;
using Vculp.DDD.Shared.Interfaces;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class AutofacConfiguration
    {
        public static void ConfigureContainer(this ContainerBuilder builder, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentException(nameof(configuration));
            }

            builder.RegisterSource(new ScopedContravariantRegistrationSource(
                typeof(ITransactionalDomainEventHandler<>),
                typeof(IAsyncDomainEventHandler<>),
                typeof(IDomainEventReducer<>)));
        }
    }
}