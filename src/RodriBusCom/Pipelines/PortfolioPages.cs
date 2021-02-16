using System.Collections.Generic;
using System.Linq;
using Contentful.Statiq;
using Microsoft.Extensions.Options;
using RodriBusCom.Models.Content;
using RodriBusCom.Modules;
using RodriBusCom.Options;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace RodriBusCom.Pipelines
{
    public class PortfolioPages : Pipeline
    {
        public const string PortfolioView = "Portfolio.cshtml";

        private readonly string[] Deps = new[]
        {
            nameof(LoadGeneralInformationEs),
            nameof(LoadPortfolioEs),
        };

        public PortfolioPages(IOptions<SiteOptions> siteOpts)
        {
            var siteOptions = siteOpts.Value;

            Dependencies.AddRange(Deps);

            ProcessModules = new ModuleList {
                // Include product view
                new ReadFiles(patterns: PortfolioView),

                // Render page
                new RenderRazor(),

                // Set destination
                new SetDestination(Config.FromDocument(_ => new NormalizedPath("portfolio.html"))),
            };

            OutputModules = new ModuleList {
                new BeautifyHtml(),
                new WriteFiles(),
            };
        }
    }
}