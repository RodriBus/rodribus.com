using System.Threading.Tasks;
using Contentful.Statiq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RodriBusCom.Extensions;
using RodriBusCom.Utils;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace RodriBusCom
{
    public class Program
    {
        public static async Task<int> Main(string[] args) =>
          await Bootstrapper
            .Factory
            .CreateWeb(args)
            // .AddSetting(WebKeys.ContentType, "Asset")
            // .AddSetting(WebKeys.Excluded, "*.cshtml")
            // .AddSetting(WebKeys.ExcludedPaths,
            //    new List<NormalizedPath>
            //    {
            //        new NormalizedPath("**/*.cshtml")
            //    })
            .BuildConfiguration(cfg => {
                cfg.AddJsonFile("appsettings.json", optional: false);
                cfg.AddUserSecrets<Program>();
            })
            .ConfigureServices((services, settings) => {
                services.AddSiteOptions((IConfiguration) settings);
                services.AddContentful((IConfiguration) settings, new EntityResolver());

                services.ConfigureGobalSettings();
                services.AddLocalization();
            })
            .AddHostingCommands()
            .AddPipelines()
            .AddCommands()
            .DisablePipeline(nameof(Statiq.Web.Pipelines.Sitemap))
            .DisablePipeline(nameof(Statiq.Web.Pipelines.Feeds))
            .DisablePipeline(nameof(Statiq.Web.Pipelines.Content))
            .RunAsync();
    }
}