using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadEducationsEs : LoadDataPipeLine<Education>
    {
        public LoadEducationsEs(IContentfulClient client) : base(client, Education.ContentTypeId, Locales.Spanish)
        {
        }
    }
}