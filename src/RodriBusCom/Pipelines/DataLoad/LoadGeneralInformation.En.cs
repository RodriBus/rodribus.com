using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadGeneralInformationEn : LoadDataPipeLine<GeneralInformation>
    {
        public LoadGeneralInformationEn(IContentfulClient client) : base(client, GeneralInformation.ContentTypeId, Locales.English)
        {
        }
    }
}