using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadSiteMetadata : LoadLocalizedDataPipeline<SiteMetadata>
    {
        public LoadSiteMetadata(IContentfulClient client) : base(client, SiteMetadata.ContentTypeId)
        {
        }
    }
}