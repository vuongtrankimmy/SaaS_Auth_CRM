using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;

namespace Infrastructures.Common.Default
{
    internal static class Startup
    {
        public static IApplicationBuilder AddDefault(this IApplicationBuilder app)
        {
            var extensionProvider = new FileExtensionContentTypeProvider();
            extensionProvider.Mappings["*.bin"]= "application/octet-stream";
            #region Default Page
            DefaultFilesOptions defaultFile = new();
            defaultFile.DefaultFileNames.Clear();
            defaultFile.DefaultFileNames.Add("swagger/index.html"); 
            app.UseDefaultFiles(defaultFile);
            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = extensionProvider
            });
            #endregion
            return app;
        }
    }
}
