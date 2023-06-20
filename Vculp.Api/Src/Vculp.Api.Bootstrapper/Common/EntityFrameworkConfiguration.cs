using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Data.EntityFramework;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class EntityFrameworkConfiguration
    {
        public static void AddEntityFrameworkConfiguration(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"{nameof(connectionString)} cannot be null, empty or contain only whitespace", nameof(connectionString));
            }

            services.AddDbContext<CoreContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    o =>
                    {
                        o.UseNetTopologySuite();
                        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                    }).EnableSensitiveDataLogging());
        }
    }
}