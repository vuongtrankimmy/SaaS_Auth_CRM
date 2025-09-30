using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Middleware.Logging
{
    internal static class Startup
    {
        public static IApplicationBuilder AddResponseTimeApp(this IApplicationBuilder app)
        {
            app.AddReponseTime();
            return app;
        }
        internal static void AddReponseTime(this IApplicationBuilder app)
        {
            app.UseMiddleware<ResponseTimeMiddle>();
        }
    }
}
