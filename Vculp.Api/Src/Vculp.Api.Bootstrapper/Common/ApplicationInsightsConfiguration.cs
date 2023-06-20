using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class ApplicationInsightsConfiguration
    {
        public static void ConfigureApplicationInsights(this IServiceCollection services, IConfiguration configuration, ApplicationInsightsWorkloadType workloadType)
        {
            if (!string.IsNullOrWhiteSpace(configuration["ApplicationInsights:ConnectionString"]))
            {
                if (workloadType == ApplicationInsightsWorkloadType.Api)
                {
                    services.AddApplicationInsightsTelemetry();

                    services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>(
                        (DependencyTrackingTelemetryModule module,
                        Microsoft.ApplicationInsights.AspNetCore.Extensions.ApplicationInsightsServiceOptions o) =>
                        {
                            module.EnableSqlCommandTextInstrumentation = true;
                        });
                }
                else
                {
                    services.AddApplicationInsightsTelemetryWorkerService();

                    services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>(
                        (DependencyTrackingTelemetryModule module,
                        Microsoft.ApplicationInsights.WorkerService.ApplicationInsightsServiceOptions o) =>
                        {
                            module.EnableSqlCommandTextInstrumentation = true;
                        });
                }


            }
        }
    }

    public enum ApplicationInsightsWorkloadType
    {
        Api,
        Worker
    }
}
