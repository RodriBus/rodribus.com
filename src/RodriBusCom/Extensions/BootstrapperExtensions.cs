using Statiq.App;

namespace RodriBusCom.Extensions
{
    public static class BootstrapperExtensions
    {
        public static Bootstrapper DisablePipeline(this Bootstrapper boostrapper, string name)
            => boostrapper.ModifyPipeline(name, _ => { });
    }
}