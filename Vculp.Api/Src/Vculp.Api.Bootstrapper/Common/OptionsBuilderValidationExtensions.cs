using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class OptionsBuilderValidationExtensions
    {
        public static OptionsBuilder<TOptions> ValidateEagerly<TOptions>(this OptionsBuilder<TOptions> optionsBuilder) where TOptions : class
        {
            optionsBuilder.Services.AddTransient<IStartupFilter, StartupOptionsValidation<TOptions>>();
            return optionsBuilder;
        }
    }
}
