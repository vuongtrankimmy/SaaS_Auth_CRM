using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Data.Html
{
    public static class HtmlPath
    {
        /// <summary>
        /// Build path HTML theo Module + relative path
        /// </summary>
        /// <param name="module">Enum: Auth, Clients, Users...</param>
        /// <param name="relativePath">Sub folder, ví dụ: "Signin", "Tasks/Detail"</param>
        /// <returns>Full path đến file .html</returns>
        public static string Get(HtmlConfig config, HtmlModule module, string relativePath)
        {
            var moduleName = module.ToString();
            var folder = relativePath.Split('/').Last();
            return $"{config.BasePath}{moduleName}/{relativePath}/{folder}.html";
        }
    }
}
