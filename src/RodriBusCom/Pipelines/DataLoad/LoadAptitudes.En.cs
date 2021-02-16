using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadAptitudesEn : LoadDataPipeLine<Aptitude>
    {
        public LoadAptitudesEn(IContentfulClient client) : base(client, Aptitude.ContentTypeId, Locales.English)
        {
        }
    }
}