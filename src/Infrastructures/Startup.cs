using Infrastructure.Middleware;
using Infrastructures.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructures
{
    public static class Startup
    {
        public static IServiceCollection UseInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services
                .UseCommon(config)
                .UseMiddleware(config);

            return services;
        }

        public static IApplicationBuilder UseInfrastructureApp(this IApplicationBuilder app, IConfiguration config)
        {
            app
                .UseCommonApp(config)
                .UseMiddlewareApp();
            return app;
        }
    }
}
