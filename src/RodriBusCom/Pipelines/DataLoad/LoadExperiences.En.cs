using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadExperiencesEn : LoadDataPipeLine<Experience>
    {
        public LoadExperiencesEn(IContentfulClient client) : base(client, Experience.ContentTypeId, Locales.English)
        {
        }
    }
}