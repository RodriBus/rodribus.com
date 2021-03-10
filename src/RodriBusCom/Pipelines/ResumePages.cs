using System.Collections.Generic;
using System.Linq;
using Contentful.Statiq;
using Microsoft.Extensions.Localization;
using RodriBusCom.Models.Content;
using RodriBusCom.Models.ViewModels;
using RodriBusCom.Modules;
using RodriBusCom.Resources;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace RodriBusCom.Pipelines
{
    public class ResumePages : Pipeline
    {
        public const string CvView = "Cv.cshtml";

        public IDictionary<string, string> PageSlugs = new Dictionary<string, string>
        {
            {Locales.Spanish, "cv" },
            {Locales.English, "resume" },
        };

        public ResumePages(IStringLocalizer<SharedResource> localizer)
        {
            Dependencies.AddRange(nameof(LoadSiteMetadata), nameof(LoadNavigation), nameof(LoadPages));

            ProcessModules = new ModuleList {
                new ReplaceDocuments(nameof(LoadPages)),
                new FilterDocuments(Config.FromDocument(doc => doc.AsContentful<Page>().Slug == PageSlugs[doc.GetString(RodriBusKeys.Locale)])),
                new MergeContent(new ReadFiles(patterns: CvView)),

                new ExtractFrontMatter(GetFrontMatterModules()),
                new RenderRazor()
                    .WithModel(Config.FromDocument((document, context) =>
                    {
                        var locale = document.GetString(RodriBusKeys.Locale);
                        var page = document.AsContentful<Page>();

                        var metadata = context.Outputs.FromPipeline(nameof(LoadSiteMetadata))
                            .Where(d => d.GetString(RodriBusKeys.Locale) == locale)
                            .Select(x => x.AsContentful<SiteMetadata>())
                            .FirstOrDefault();

                        var navigation = context.Outputs.FromPipeline(nameof(LoadNavigation))
                            .Where(d => d.GetString(RodriBusKeys.Locale) == locale)
                            .Select(x => x.AsContentful<Navigation>())
                            .FirstOrDefault();

                        return new HomeViewModel(page, metadata, navigation, localizer, locale);
                    }
                    )),

                new SetDestination(Config.FromDocument(doc  =>
                {
                    var path = PageSlugs[doc.GetString(RodriBusKeys.Locale)] + ".html";
                    var locale = doc.GetString(RodriBusKeys.Locale);
                    var pathStart = Locales.GetPath(locale);
                    if (!string.IsNullOrEmpty(pathStart)) path = $"{pathStart}/{path}";
                    return new NormalizedPath(path);
                })),
            };

            OutputModules = new ModuleList {
                new ExecuteIf(Config.FromSetting(RodriBusKeys.MinifyPages, true), new MinifyHtml())
                    .Else(new BeautifyHtml()),
                new WriteFiles(),
            };
        }

        private static IModule[] GetFrontMatterModules()
        {
            var modules = new ModuleList {
                new Statiq.Yaml.ParseYaml()
            };
            return modules.ToArray();
        }
    }
}