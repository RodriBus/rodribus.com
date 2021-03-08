using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RodriBusCom;
using RodriBusCom.Options;

namespace RodriBusCom.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSiteOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<SiteOptions>(configuration.GetSection("SiteOptions"));
            return services;
        }

        public static IServiceCollection ConfigureGobalSettings(this IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            GlobalSettings.Configure(sp.GetService<IOptions<SiteOptions>>().Value);
            return services;
        }
    }
}