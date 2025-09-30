using Fluid;
using Helpers.Helper.Convert;
using HtmlAgilityPack;
using ZetaProducerHtmlCompressor;

namespace Shared.Helpers.Template.Html
{
    public static class HtmlTemplate
    {
        private static readonly FluidParser _parser = new();
        public static async Task<string> ToRender<tEntity>(this string source, tEntity json)
        {
            var html = "";
            var doc = new HtmlDocument();
            if (!File.Exists(source)) return html;
            doc.Load(source);
            var node = doc.DocumentNode.SelectSingleNode("/html/body");
            var NodeString = node.InnerHtml;

            if (_parser.TryParse(NodeString, out var template, out var error))
            {
                var dic = json.ToSerialize();
                var context = new TemplateContext(dic,true);
                var content = await template.RenderAsync(context);
                var compressor = new HtmlContentCompressor();
                html = compressor.Compress(content);
            }
            else
            {
                Console.WriteLine($"Error: {error}");
            }
            return html;
        }
    }
}
