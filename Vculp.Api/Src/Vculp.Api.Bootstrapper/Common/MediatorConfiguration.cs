using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.DDD.Shared;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class MediatorConfiguration
    {
        public static void ConfigureMediator(this IServiceCollection services, Action<IServiceCollection> pipelineConfigurationAction)
        {
            services.AddMediatR(typeof(QueryHandler));
            services.AddMediatR(typeof(CommandHandler));
            services.AddScoped(typeof(PipelineContext));

            pipelineConfigurationAction?.Invoke(services);
        }
    }
}
