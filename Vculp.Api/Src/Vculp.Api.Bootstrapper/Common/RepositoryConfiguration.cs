using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Data.EntityFramework;
using Vculp.Api.Data.EntityFramework.Common;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<CoreContext>()
                .AddClasses(classes => classes.AssignableTo(typeof(Repository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.Scan(scan => scan
                .FromAssemblyOf<CoreContext>()
                .AddClasses(classes => classes.AssignableTo(typeof(ReadRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

             

             
            // Outbox
            //services.AddTransient<IOutboxMessageRepository, OutboxMessageRepository>();

            
            //Application Permission
            // services.Decorate<IApplicationPermissionRepository>((inner, services) =>
            // {
            //     var applicationPermissionCache = services.GetRequiredService<IApplicationPermissionCache>();
            //     return new CachingApplicationPermissionRepository(inner, applicationPermissionCache);
            // });
        }
    }
}

