using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadGeneralInformationEs : LoadDataPipeLine<GeneralInformation>
    {
        public LoadGeneralInformationEs(IContentfulClient client) : base(client, GeneralInformation.ContentTypeId, Locales.Spanish)
        {
        }
    }
}