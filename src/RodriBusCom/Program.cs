﻿using System.Threading.Tasks;
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
            .BuildConfiguration(cfg => {
                cfg.AddJsonFile("appsettings.json", optional: false);
                cfg.AddEnvironmentVariables();
                cfg.AddCommandLine(args);
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
            .DeployToGitHubPagesBranch(
                Config.FromSetting<string>("REPO_OWNER"),
                Config.FromSetting<string>("REPO_NAME"),
                Config.FromSetting<string>("GITHUB_TOKEN"),
                Config.FromSetting<string>("REPO_BRANCH")
            )
            .RunAsync();
    }
}