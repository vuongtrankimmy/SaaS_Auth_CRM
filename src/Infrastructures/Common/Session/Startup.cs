using Infrastructures.Common.Session.SessionMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.Common.Session
{
    public static class Startup
    {
        public static IServiceCollection AddSession(this IServiceCollection services)
        {            
            services.Session();            
            return services;
        }

        internal static void Session(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        public static IApplicationBuilder AddSessionApp(this IApplicationBuilder app)
        {
            //app.UseSession(); // Đảm bảo sử dụng session
            //app.UseMiddleware<SessionCheckMiddleware>();

            // Các middleware khác
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    //endpoints.MapBlazorHub();
            //    //endpoints.MapFallbackToPage("/_Host");
            //});
            return app;
        }
    }
}
