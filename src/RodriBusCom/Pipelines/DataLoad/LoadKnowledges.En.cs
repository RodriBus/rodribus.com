using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadKnowledgesEn : LoadDataPipeLine<Knowledge>
    {
        public LoadKnowledgesEn(IContentfulClient client) : base(client, Knowledge.ContentTypeId, Locales.English)
        {
        }
    }
}