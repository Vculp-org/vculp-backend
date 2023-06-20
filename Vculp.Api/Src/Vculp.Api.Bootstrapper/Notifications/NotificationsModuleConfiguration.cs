using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Vculp.Api.Common.Notifications.Configs;
using Vculp.Api.Domain.Common.EmailSender;
using Vculp.Api.Domain.Common.SmsSenders;
using Vculp.Api.Domain.Interfaces.EmailSender;
using Vculp.Api.Domain.Interfaces.SMSSender;

namespace Vculp.Api.Bootstrapper.Notifications
{
    public static class NotificationsModuleConfiguration
    {
        public static void ConfigureNotificationsModule(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.Configure<NotificationsConfiguration>(configuration.GetSection("NotificationsConfiguration"));
            services.ConfigureEmailModule();
            services.ConfigureSmsModule();

        }

        #region Email

        public static void ConfigureEmailModule(this IServiceCollection services)
        {
            services.AddSingleton<IEmailSender>(implementationFactory =>
            {
                var notificationOptions =
                    implementationFactory.GetRequiredService<IOptions<NotificationsConfiguration>>();
                if (notificationOptions.Value.EmailConfiguration.IsProductionModeEnabled)
                    return new EmailSender(notificationOptions?.Value.EmailConfiguration);
                return new DevEmailSender(notificationOptions?.Value.EmailConfiguration);

            });

             
        }

        public static void ConfigureSmsModule(this IServiceCollection services)
        {
            services.AddSingleton<ISmsSender>(implementationFactory =>
            {
                var notificationOptions =
                    implementationFactory.GetRequiredService<IOptions<NotificationsConfiguration>>();

                var sendModeService = implementationFactory.GetRequiredService<ISendModeService>();

                if (notificationOptions.Value.SmsConfiguration.IsProductionModeEnabled)
                    return new SmsSender(sendModeService, notificationOptions.Value.SmsConfiguration);
                return new DevSmsSender(sendModeService, notificationOptions.Value.SmsConfiguration);

            });

            services.AddHttpClient<ISendModeService, SendModeService>()
                .ConfigureHttpClient((serviceProvider, client) =>
                {

                    //Fetch SMS API Settings from configuration
                    var notificationsConfiguration = serviceProvider
                        .GetRequiredService<IOptions<NotificationsConfiguration>>().Value;

                    //Set Client Base Address URL
                    if (string.IsNullOrEmpty(notificationsConfiguration?.SmsConfiguration?.BaseUrl))
                        throw new ArgumentNullException(nameof(notificationsConfiguration.SmsConfiguration.BaseUrl));

                    client.BaseAddress = new Uri(notificationsConfiguration.SmsConfiguration?.BaseUrl);

                    //Set Client Authorization headers 
                    if (string.IsNullOrEmpty(notificationsConfiguration?.SmsConfiguration?.AccessKey))
                        throw new ArgumentNullException(nameof(notificationsConfiguration.SmsConfiguration.AccessKey));

                    client.DefaultRequestHeaders.Add("Authorization",
                        notificationsConfiguration?.SmsConfiguration.AccessKey);

                    //Set Client Timeout if any
                    if (notificationsConfiguration?.SmsConfiguration?.TimeOutSeconds != 0)
                        client.Timeout =
                            TimeSpan.FromSeconds(notificationsConfiguration.SmsConfiguration.TimeOutSeconds);
                }).SetHandlerLifetime(TimeSpan.FromMinutes(5));
            //Set 5 min as the lifetime for the HttpMessageHandler objects in the pool used for the ISendModeService Typed Client
        }

         
        #endregion

    }
}