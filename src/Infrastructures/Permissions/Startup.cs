using Infrastructures.Permissions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.Infrastructure.Auth;

internal static class Startup
{
    internal static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddCurrentUser();
            //.AddPermissions();
        services.Configure<SecuritySettings>(config.GetSection(nameof(SecuritySettings)));
        return services;
    }

    internal static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app) =>
        app.UseMiddleware<CurrentUserMiddleware>();

    private static IServiceCollection AddCurrentUser(this IServiceCollection services) =>
        services
            .AddScoped<CurrentUserMiddleware>()
            .AddScoped<ICurrentUser, CurrentUser>()
            .AddScoped(sp => (ICurrentUserInitializer)sp.GetRequiredService<ICurrentUser>());

    //private static IServiceCollection AddPermissions(this IServiceCollection services) =>
    //    services
    //        .AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>()
    //        .AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
}