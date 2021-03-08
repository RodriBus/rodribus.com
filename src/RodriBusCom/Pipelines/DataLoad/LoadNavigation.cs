using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadNavigation : LoadLocalizedDataPipeline<Navigation>
    {
        public LoadNavigation(IContentfulClient client) : base(client, Navigation.ContentTypeId)
        {
        }
    }
}