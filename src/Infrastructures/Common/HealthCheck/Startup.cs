using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Infrastructures.Common.HealthCheck
{
    internal static class Startup
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services)
        {
            services.HealthCheck();
            return services;
        }

        public static IApplicationBuilder AddHealthCheckApp(this IApplicationBuilder app)
        {
            app.HealthCheckApp();
            return app;
        }

        internal static void HealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks().AddCheck("Diadiem",
                () =>
                {
                    return HealthCheckResult.Degraded("The check of the service did not work well");
                }
            ).AddCheck("Database",
            () => HealthCheckResult.Healthy("The check of the database worked."));
        }

        internal static IApplicationBuilder HealthCheckApp(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/quickhealth", new HealthCheckOptions()
                {
                    Predicate = _ => false
                });
                endpoints.MapHealthChecks("/health/service", new HealthCheckOptions()
                {
                    Predicate = reg => reg.Tags.Contains("service"),
                    //ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    //ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                //endpoints.MapHealthChecksUI();
                endpoints.MapControllers();
            });
            return app;
        }
    }
}