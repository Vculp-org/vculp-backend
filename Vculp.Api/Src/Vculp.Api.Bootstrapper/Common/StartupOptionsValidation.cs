﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace Vculp.Api.Bootstrapper.Common
{
    public class StartupOptionsValidation<T> : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                var options = builder.ApplicationServices.GetService(typeof(IOptions<>).MakeGenericType(typeof(T)));
                if (options != null)
                {
                    // Retrieve the value to trigger validation
                    var optionsValue = ((IOptions<object>)options).Value;
                }

                next(builder);
            };
        }
    }
}
