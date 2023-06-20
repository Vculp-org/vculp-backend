using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Data.EntityFramework;

namespace Vculp.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static void BootstrapVculpDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper, UrlHelper>(factory =>
            {
                var actionContext = factory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });
            

            services.AddTransient<ValidationMessagesBuilder>();

            BootstrapRbacDependecies(services);
            BootstrapNotificationDependecies(services);
        }
    }
}
