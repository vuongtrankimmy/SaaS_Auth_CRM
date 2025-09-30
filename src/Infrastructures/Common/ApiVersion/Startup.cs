using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.Common.ApiVersion
{
    internal static class Startup
    {
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            services.ApiVersion();
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            //services.AddSwaggerGen(options =>
            //{
            //    // Add a custom operation filter which sets default values
            //    options.OperationFilter<SwaggerDefaultValues>();
            //});
            return services;
        }
        internal static void ApiVersion(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                //options.ApiVersionReader = new QueryStringApiVersionReader();
                options.ReportApiVersions = true;
                //options.ApiVersionReader = new UrlSegmentApiVersionReader();
                //options.ApiVersionReader = new HeaderApiVersionReader("v");
                //options.ApiVersionReader = new MediaTypeApiVersionReader("v");
                //options.ApiVersionReader =
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("x-api-version"),
                    new MediaTypeApiVersionReader("x-api-version"));
            }).AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service  
                // note: the specified format code will format the version as "'v'major[.minor][-status]"  
                options.GroupNameFormat = "'v'VVV";
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat  
                // can also be used to control the format of the API version in route templates  
                options.SubstituteApiVersionInUrl = true;
            }).AddMvc();
        }
    }
}
