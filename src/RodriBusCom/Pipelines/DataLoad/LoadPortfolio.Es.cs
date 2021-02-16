using Contentful.Core;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Pipelines
{
    public class LoadPortfolioEs : LoadDataPipeLine<Portfolio>
    {
        public LoadPortfolioEs(IContentfulClient client) : base(client, Portfolio.ContentTypeId, Locales.Spanish)
        {
        }
    }
}