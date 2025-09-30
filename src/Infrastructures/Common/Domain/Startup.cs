using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructures.Common.Domain
{
    public class DomainMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public DomainMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var domain = _configuration["DomainSetting:domain"];
            // Thực hiện các hành động với domain, ví dụ như đặt vào Response headers
            //context.Response.Headers.Add("X-Custom-Domain", domain);
            await _next(context);
        }
    }

    public static class DomainMiddlewareExtensions
    {
        public static IApplicationBuilder UseDomainMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DomainMiddleware>();
        }
    }
}
