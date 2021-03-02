using System;
using System.Linq;
using Contentful.Statiq;
using Statiq.Common;
using Statiq.Core;

namespace RodriBusCom.Pipelines
{
    public class SitemapPipeline : Pipeline
    {
        public SitemapPipeline()
        {
            Dependencies.AddRange(nameof(HomePipeline), nameof(PortfolioPages), nameof(ResumePages));
            ProcessModules = new ModuleList(
                new ReplaceDocuments(Dependencies.ToArray()),
                new SetMetadata(Keys.SitemapItem, Config.FromDocument((doc, _) => {
                    var siteMapItem = new SitemapItem(doc.Destination.FullPath) {
                        LastModUtc = doc.Get<DateTime?>(ContentfulKeys.System.UpdatedAt, null)
                    };

                    if (!siteMapItem.LastModUtc.HasValue) {
                        siteMapItem.LastModUtc = DateTime.UtcNow;
                        siteMapItem.ChangeFrequency = SitemapChangeFrequency.Weekly;
                    }
                    else {
                        siteMapItem.ChangeFrequency = SitemapChangeFrequency.Monthly;
                    }

                    return siteMapItem;
                })),

                new GenerateSitemap()
            );

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }
    }
}