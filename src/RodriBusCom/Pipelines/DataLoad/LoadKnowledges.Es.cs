using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadKnowledgesEs : LoadDataPipeLine<Knowledge>
    {
        public LoadKnowledgesEs(IContentfulClient client) : base(client, Knowledge.ContentTypeId, Locales.Spanish)
        {
        }
    }
}