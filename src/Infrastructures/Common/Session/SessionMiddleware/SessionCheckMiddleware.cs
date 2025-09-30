using Infrastructures.Common.Session.Session;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Infrastructures.Common.Session.SessionMiddleware
{
    public class SessionCheckMiddleware
    {
        private readonly RequestDelegate _next;
        //public IShare _share { get; set; } = default!;
        public SessionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var allowedPaths = new[] { "/", "/auth", "/introduce" }; // Các trang được phép
            if (context.Session != null)
            {
                var sessionValue = context.Session.GetString(SessionName.authToken.ToString());
                if (allowedPaths.Any(path => !path.Equals(context.Request.Path, StringComparison.OrdinalIgnoreCase)) && string.IsNullOrEmpty(sessionValue))
                {
                    context.Response.Redirect("/auth");
                    return;
                }
            }
            await _next(context);
        }
    }
}
