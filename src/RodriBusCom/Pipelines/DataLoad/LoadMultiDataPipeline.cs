using System.Collections.Generic;
using Contentful.Core;
using Contentful.Statiq;
using Statiq.Common;
using Statiq.Core;

namespace RodriBusCom.Pipelines
{
    public abstract class LoadMultiDataPipeLine<TContentModel> : Pipeline where TContentModel : class
    {
        protected LoadMultiDataPipeLine(IContentfulClient client, string contentTypeId, IEnumerable<string> locales)
        {
            InputModules = new ModuleList
            {
                new Contentful<TContentModel>(client, contentTypeId)
                    .WithQuery(q => {
                        q.Include(10);
                        q.LocaleIs("");
                    })
                    .WithContent(x => Newtonsoft.Json.JsonConvert.SerializeObject(x, Newtonsoft.Json.Formatting.Indented)),
                new SetMetadata(RodriBusKeys.Locale,
                    Config.FromDocument((doc, __) => doc.Get<string>(ContentfulKeys.System.Locale))),
            };
        }
    }
}