using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.Middleware.ExceptionMiddleware
{
    internal static class Startup
    {
        public static IServiceCollection AddExceptionMiddle(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<ErrorHandlingService>();
            return services;
        }

        public static IApplicationBuilder AddExceptionApp(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));
            return app;
        }
    }
}
