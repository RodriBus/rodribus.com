using Statiq.Common;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using AngleSharp.Html;

namespace RodriBusCom.Modules
{
    public class MinifyHtml : Module
    {
        protected override async Task<IEnumerable<IDocument>> ExecuteInputAsync(IDocument input, IExecutionContext context)
        {
            var str = await input.GetContentStringAsync();

            var formatted = Minify(str);
            return input
                .Clone(context.GetContentProvider(formatted, input.ContentProvider.MediaType))
                .Yield();
        }

        private static string Minify(string newContent)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(newContent);

            using var sw = new StringWriter();
            document.ToHtml(sw, new MinifyMarkupFormatter());
            return sw.ToString();
        }
    }
}