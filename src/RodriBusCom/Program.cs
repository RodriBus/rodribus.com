using Contentful.Statiq;
using Microsoft.Extensions.Configuration;
using RodriBusCom.Extensions;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;
using System.Threading.Tasks;

namespace RodriBusCom
{
    public class Program
    {
        public static async Task<int> Main(string[] args) =>
          await Bootstrapper
            .Factory
            .CreateWeb(args)
            .BuildConfiguration(cfg => {
                cfg.AddJsonFile("appsettings.json", optional: false);
                cfg.AddUserSecrets<Program>();
            })
            .ConfigureServices((services, settings) => {
                services.AddSiteOptions((IConfiguration) settings);
                services.AddContentful((IConfiguration) settings);

                services.ConfigureGobalSettings();
            })
            .AddHostingCommands()
            .AddPipelines()
            .AddCommands()
            .RunAsync();
    }
}