using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Common;

namespace Vculp.Api
{
    public static class MediatorPipelineConfiguration
    {
        public static void ConfigureApiMediatorPipeline(this IServiceCollection services)
        {
            //Query Pipeline Configuration

            //Caching Behaviors - Post Processing
            

            //Link Generating Behaviors - Post Procesing
            
            //Query Validating Behaviors - Pre Processing
            

            //Routable Behaviors - Pre Processing


            //Authorizing Behaviors - Pre Processing


            //Custom Behaviors - Pre Processing

            //Custom Behaviors - Post Processing

            //Command Pipline Configuration

            //Link Generating Behaviors - Post Processing

            // Message Context Setting Behavior - Pre Processing
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandMessageContextPopulatingBehaviour<,>));

            //Routable Behaviours - Pre Processing

            //Command Authorizing Behaviors - Pre Processing

            //Command Validating Behaviors - Pre Processing

            //Custom Behaviors
        }
    }
}
