using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadPortfolioEn : LoadDataPipeLine<Portfolio>
    {
        public LoadPortfolioEn(IContentfulClient client) : base(client, Portfolio.ContentTypeId, Locales.English)
        {
        }
    }
}