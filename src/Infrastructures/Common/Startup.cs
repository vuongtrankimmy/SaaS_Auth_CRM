using Infrastructures.Common.ApiVersion;
using Infrastructures.Common.Caching;
using Infrastructures.Common.Cors;
using Infrastructures.Common.Default;
using Infrastructures.Common.Domain;
using Infrastructures.Common.GZip;
using Infrastructures.Common.HealthCheck;
using Infrastructures.Common.HSTS;
using Infrastructures.Common.Lazy;
using Infrastructures.Common.Localization;
using Infrastructures.Common.Serializer;
using Infrastructures.Common.Session;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.Common
{
    internal static class Startup
    {
        public static IServiceCollection UseCommon(this IServiceCollection services, IConfiguration config)
        {
            //var applicationAssembly = typeof(Application.Startup).GetTypeInfo().Assembly;
            services
                .AddApiVersion()
                .AddCaching(config)
                .AddCorsPolicy(config)
                .AddGZip()
                .AddHealthCheck()
                .AddHSTS()
                .AddLazy()
                //.AddSession()
                .UseLocalization(config)
                .AddSerializer();
                //.AddDotNet()
                
            return services;
        }

        public static IApplicationBuilder UseCommonApp(this IApplicationBuilder app, IConfiguration config)
        {
            app.AddCachingApp()
                .AddSessionApp()
                .AppLanguage(config)
                .UseCorsPolicy()
                //.HealthCheckApp()
                .AddDefault()
                .UseDomainMiddleware();
                
            return app;
        }
    }
}
