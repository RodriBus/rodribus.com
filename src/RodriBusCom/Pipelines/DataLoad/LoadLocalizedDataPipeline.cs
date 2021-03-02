using Contentful.Core;
using Contentful.Statiq;
using RodriBusCom.Extensions;
using Statiq.Common;
using Statiq.Core;

namespace RodriBusCom.Pipelines
{
    public abstract class LoadLocalizedDataPipeline<TContentModel> : Pipeline where TContentModel : class
    {
        protected LoadLocalizedDataPipeline(IContentfulClient client, string contentTypeId)
        {
            InputModules = new ModuleList
            {
                // Load With ES locale
                new Contentful<TContentModel>(client, contentTypeId)
                    .WithQuery(q => {
                        q.Include(10);
                        q.LocaleIs(Locales.Spanish);
                    })
                    .WithSerializedContent(),

                // Concat with EN locale
                new ConcatDocuments(
                        new Contentful<TContentModel>(client, contentTypeId)
                            .WithQuery(q => {
                                q.Include(10);
                                q.LocaleIs(Locales.English);
                            })
                            .WithSerializedContent()
                    ),

                // Set Locale as metadata
                new SetMetadata(RodriBusKeys.Locale, Config.FromDocument(doc => doc.Get<string>(ContentfulKeys.System.Locale))),
            };
        }
    }
}