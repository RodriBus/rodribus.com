using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadExperiencesEs : LoadDataPipeLine<Experience>
    {
        public LoadExperiencesEs(IContentfulClient client) : base(client, Experience.ContentTypeId, Locales.Spanish)
        {
        }
    }
}