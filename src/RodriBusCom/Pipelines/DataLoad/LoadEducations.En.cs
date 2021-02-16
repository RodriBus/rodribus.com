using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadEducationsEn : LoadDataPipeLine<Education>
    {
        public LoadEducationsEn(IContentfulClient client) : base(client, Education.ContentTypeId, Locales.English)
        {
        }
    }
}