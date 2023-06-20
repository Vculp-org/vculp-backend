using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.Notifications.Commands;
using Vculp.Api.Common.Notifications.Responses;
using Vculp.Api.Notifications.Helpers;
using Vculp.Api.Notifications.Validators;

namespace Vculp.Api
{
    public static partial class ServiceCollectionExtensions
    {
        public static void BootstrapNotificationDependecies(this IServiceCollection services)
        {
            #region Link Generators
            services.AddTransient<IHateoasLinkGenerator<ContactResponse>, ContactLinkGenerator>();
            #endregion

            #region Validators
            services.AddTransient<IValidator<DistributeBulkNotificationCommand>, DistributeBulkNotificationCommandValidator>();
            #endregion
        }
    }
}
