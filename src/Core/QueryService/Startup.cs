using Helpers.Helper.Convert;
using Microsoft.Extensions.DependencyInjection;
using QueryService.Features.Pages.v1.Auth;
using QueryService.Wrapper;
using Repositories.Repository;
namespace QueryService
{
    public static class Startup
    {
        public static IServiceCollection UseQueryService(this IServiceCollection services)
        {
            services.DIRegisters();
            return services;
        }
        private static IServiceCollection DIRegisters(this IServiceCollection services)
        {
            services.AddScoped<JsonService>();
            services.AddScoped<IQueryWrapper, QueryWrapper>();
            services.AddScoped<IAuthQuery, AuthQuery>();
            services.AddScoped<IQueryRepository, QueryRepository>();
            return services;
        }
    }
}
