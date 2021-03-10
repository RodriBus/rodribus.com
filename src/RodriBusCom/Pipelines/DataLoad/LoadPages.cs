using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadPages : LoadLocalizedDataPipeline<Page>
    {
        public LoadPages(IContentfulClient client) : base(client, Page.ContentTypeId)
        {
        }
    }
}