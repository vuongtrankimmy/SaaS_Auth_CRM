using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Data.Html
{
    public class HtmlConfig
    {
        public string DataRoot { get; set; } = "wwwroot/data";
        public HtmlChannel Channel { get; set; } = HtmlChannel.Mobile;
        public string Version { get; set; } = "v1";

        public string BasePath => $"{DataRoot}/html/{Channel.ToString().ToLower()}/{Version}/Components/Pages/";
    }
}
