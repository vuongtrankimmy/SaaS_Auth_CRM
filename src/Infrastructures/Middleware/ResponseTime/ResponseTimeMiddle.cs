using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Middleware.Logging
{
    internal class ResponseTimeMiddle
    {
        // Name of the Response Header, Custom Headers starts with "X-"  
        private const string ResponseHeaderResponseTime = "X-Response-Time-ms";

        // Handle to the next Middleware in the pipeline  
        private readonly RequestDelegate _next;

        ///<inheritdoc/>
        public ResponseTimeMiddle(RequestDelegate next)
        {
            _next = next;
        }

        ///<inheritdoc/>
        public Task InvokeAsync(HttpContext context)
        {
            // skipping measurement of non-actual work like OPTIONS
            if (context.Request.Method == "OPTIONS")
                return _next(context);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB", false);
            // Start the Timer using Stopwatch  
            var watch = new Stopwatch();
            watch.Start();
            try
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.OnStarting(() =>
                    {
                        // Stop the timer information and calculate the time   
                        watch.Stop();
                        var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                        // Add the Response time information in the Response headers.   
                        context.Response.Headers[ResponseHeaderResponseTime] = responseTimeForCompleteRequest.ToString();

                        //var logger = context.RequestServices.GetService<ILoggerManager>();
                        string fullUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
                        var log = $"[Performance] Request to {fullUrl} took {responseTimeForCompleteRequest} ms";
                        //logger?.LogDebug(log);
                        Console.WriteLine(log);
                        return Task.CompletedTask;
                    });
                }
            }
            catch (System.Exception e)
            {
#pragma warning disable CS8604 // Possible null reference argument.
                return context.Response.WriteAsync(e.StackTrace);
#pragma warning restore CS8604 // Possible null reference argument.
            }
            // Call the next delegate/middleware in the pipeline   
            return _next(context);
        }
    }
}
