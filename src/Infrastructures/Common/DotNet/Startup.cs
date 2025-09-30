using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.Common.DotNet
{
    internal static class Startup
    {
        public static IServiceCollection AddDotNet(this IServiceCollection services)
        {
            services.AddSingleton<DotNetService>();
            return services;
        }
    }
}
