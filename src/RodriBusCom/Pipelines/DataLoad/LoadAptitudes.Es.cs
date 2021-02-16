using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadAptitudesEs : LoadDataPipeLine<Aptitude>
    {
        public LoadAptitudesEs(IContentfulClient client) : base(client, Aptitude.ContentTypeId, Locales.Spanish)
        {
        }
    }
}