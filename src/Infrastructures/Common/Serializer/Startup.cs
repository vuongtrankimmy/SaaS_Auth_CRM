using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Infrastructures.Common.Serializer
{
    internal static class Startup
    {
        public static IServiceCollection AddSerializer(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition =  JsonIgnoreCondition.WhenWritingDefault 
                | JsonIgnoreCondition.WhenWritingNull;//Bỏ qua giá trị null trả về
                //options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }).AddJsonOptions(opt =>
            {
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problems = new CustomBadRequest(context);

                    return new BadRequestObjectResult(problems);
                };
            });
            return services;
        }
    }
}