using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Common.AntiForgey
{
    internal static class Startup
    {
        public static IServiceCollection AddAntiForgey(this IServiceCollection services)
        {
            services.AntiForgey();
            return services;
        }

        public static IApplicationBuilder AddAntiForgeyApp(this IApplicationBuilder app, IAntiforgery antiforgery)
        {
            app.AntiForgeyApp(antiforgery);
            return app;
        }

        internal static void AntiForgey(this IServiceCollection services)
        {
            services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties†.
                options.FormFieldName = "Antiforgery";
                options.HeaderName = "XSRF-TOKEN";
                options.SuppressXFrameOptionsHeader = false;
            });
            services.AddControllersWithViews(options =>
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        }

        internal static void AntiForgeyApp(this IApplicationBuilder app, IAntiforgery antiforgery)
        {
            app.Use(next => context =>
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string path = context.Request.Path.Value;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                if (
                    string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
                {
                    // The request token can be sent as a JavaScript-readable cookie, 
                    // and Angular uses it by default.
                    var tokens = antiforgery.GetAndStoreTokens(context);
#pragma warning disable CS8604 // Possible null reference argument.
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                        new CookieOptions() { HttpOnly = false });
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return next(context);
            });
        }
    }
}
