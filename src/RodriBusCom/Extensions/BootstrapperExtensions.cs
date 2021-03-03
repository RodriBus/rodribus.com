using Statiq.App;
using Statiq.Common;

namespace RodriBusCom.Extensions
{
    public static class BootstrapperExtensions
    {
        public static Bootstrapper DisablePipeline(this Bootstrapper boostrapper, string name)
            => boostrapper.ConfigureEngine(e => e.Pipelines.Remove(name));
    }
}