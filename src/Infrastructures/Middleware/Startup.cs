using Infrastructures.Middleware.ExceptionMiddleware;
using Infrastructures.Middleware.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Middleware;

internal static class Startup
{
    public static IServiceCollection UseMiddleware(this IServiceCollection services, IConfiguration config)
    {
        //var applicationAssembly = typeof(Application.Startup).GetTypeInfo().Assembly;
        services.AddExceptionMiddle(config);
        return services;
    }

    public static IApplicationBuilder UseMiddlewareApp(this IApplicationBuilder app)
    {
        app.AddExceptionApp();
        app.AddResponseTimeApp();
        return app;
    }
}