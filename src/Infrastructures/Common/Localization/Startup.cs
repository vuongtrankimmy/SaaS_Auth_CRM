using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Localization;
using Shared.Localizations;
using System.Globalization;

namespace Infrastructures.Common.Localization
{
    internal static class Startup
    {
        public static IServiceCollection UseLocalization(this IServiceCollection services, IConfiguration config)
        {
            services.Localization(config);

            return services;
        }

        internal static void Localization(this IServiceCollection services, IConfiguration config)
        {
            var localizationSettings = config.GetSection(nameof(LocalizationSettings)).Get<LocalizationSettings>();

            if (localizationSettings?.EnableLocalization is true
                && localizationSettings.ResourcesPath is not null)
            {
                //services.AddPortableObjectLocalization(options => options.ResourcesPath = localizationSettings.ResourcesPath);
                services.AddLocalization();
                services.Configure<RequestLocalizationOptions>(options =>
                {
                    if (localizationSettings.SupportedCultures != null)
                    {
                        var supportedCultures = localizationSettings.SupportedCultures.Select(x => new CultureInfo(x)).ToList();

                        options.SupportedCultures = supportedCultures;
                        options.SupportedUICultures = supportedCultures;
                    }

                    options.DefaultRequestCulture = new RequestCulture(localizationSettings.DefaultRequestCulture ?? "en-US");
                    options.FallBackToParentCultures = localizationSettings.FallbackToParent ?? true;
                    options.FallBackToParentUICultures = localizationSettings.FallbackToParent ?? true;
                    options.RequestCultureProviders = [new RouteDataRequestCultureProvider { Options = new RequestLocalizationOptions() }];
                });
                services.AddSingleton<ILocalizationFileLocationProvider, PoFileLocationProvider>();
                services.AddSingleton<Localizer>();
            }
        }

        public static IApplicationBuilder AppLanguage(this IApplicationBuilder app, IConfiguration config)
        {
            var localizationSettings = config.GetSection(nameof(LocalizationSettings)).Get<LocalizationSettings>();
            var supportedCultures = localizationSettings?.SupportedCultures?.Select(x => new CultureInfo(x)).ToList();
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                DefaultRequestCulture = new RequestCulture(localizationSettings?.DefaultRequestCulture ?? "en-US"),
                FallBackToParentCultures = localizationSettings?.FallbackToParent ?? true,
                FallBackToParentUICultures = localizationSettings?.FallbackToParent ?? true,
                RequestCultureProviders = [new RouteDataRequestCultureProvider { Options = new RequestLocalizationOptions() }]
            });
            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            return app;
        }
    }
}