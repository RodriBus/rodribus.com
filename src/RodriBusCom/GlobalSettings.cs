using System;
using RodriBusCom.Options;

namespace RodriBusCom
{
    public static class GlobalSettings
    {
        private static bool Configured { get; set; }

        private static SiteOptions _siteOptions;

        public static SiteOptions SiteOptions => _siteOptions
                ?? throw new InvalidOperationException("Site options hasn't been configured in global settings.");

        public static void Configure(SiteOptions siteOptions)
        {
            ThrowIfConfigured();
            _siteOptions = siteOptions;
            Configured = true;
        }

        private static void ThrowIfConfigured()
        {
            if (Configured)
                throw new InvalidOperationException("Cannot configure global settings more than once.");
        }
    }
}