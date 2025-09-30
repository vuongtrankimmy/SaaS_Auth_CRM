using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Common.Lazy
{
    internal static class Startup
    {
        public static IServiceCollection AddLazy(this IServiceCollection services)
        {
            services.Lazy();
            return services;
        }

        internal static void Lazy(this IServiceCollection services)
        {
            services.AddTransient(
                typeof(Lazy<>),
                typeof(LazilyResolved<>));
        }
        private class LazilyResolved<T> : Lazy<T>
        {
            public LazilyResolved(IServiceProvider serviceProvider)
                : base(serviceProvider.GetRequiredService<T>)
            {
            }
        }
    }
}
