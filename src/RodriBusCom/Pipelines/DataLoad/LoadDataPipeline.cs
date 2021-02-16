using Contentful.Core;
using Contentful.Statiq;
using Statiq.Common;
using Statiq.Core;

namespace RodriBusCom.Pipelines
{
    public abstract class LoadDataPipeLine<TContentModel> : Pipeline where TContentModel : class
    {
        protected LoadDataPipeLine(IContentfulClient client, string contentTypeId, string locale)
        {
            InputModules = new ModuleList
            {
                new Contentful<TContentModel>(client, contentTypeId)
                    .WithQuery(q => {
                        q.Include(10);
                        q.LocaleIs(locale);
                    })
                    .WithContent(x => Newtonsoft.Json.JsonConvert.SerializeObject(x, Newtonsoft.Json.Formatting.Indented)),
                new SetMetadata(RodriBusKeys.Locale,
                    Config.FromDocument((doc, __) => doc.Get<string>(ContentfulKeys.System.Locale))),
            };
        }
    }
}