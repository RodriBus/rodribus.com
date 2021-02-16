using Statiq.Common;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using AngleSharp.Html;

namespace RodriBusCom.Modules
{
    public class BeautifyHtml : Module
    {
        protected override async Task<IEnumerable<IDocument>> ExecuteInputAsync(IDocument input, IExecutionContext context)
        {
            var str = await input.GetContentStringAsync();

            var formatted = PrettifyHtml(str);
            return input
                .Clone(await context.GetContentProviderAsync(formatted, input.ContentProvider.MediaType))
                .Yield();
        }

        private static string PrettifyHtml(string newContent)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(newContent);

            using var sw = new StringWriter();
            document.ToHtml(sw, new PrettyMarkupFormatter());
            return sw.ToString();
        }
    }
}