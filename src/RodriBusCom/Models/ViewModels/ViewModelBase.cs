using System.Globalization;
using Microsoft.Extensions.Localization;
using RodriBusCom.Models.Content;
using RodriBusCom.Resources;

namespace RodriBusCom.Models.ViewModels
{
    public abstract class ViewModelBase
    {
        protected ViewModelBase(SiteMetadata metadata, Navigation navigation, IStringLocalizer<SharedResource> localizer, string locale = Locales.Spanish)
        {
            Author = metadata.Author as Author;
            Metadata = metadata;
            Navigation = navigation;
            Locale = locale;
            CultureInfo = CultureInfo.CreateSpecificCulture(Locale);
#pragma warning disable CS0618 // Type or member is obsolete
            Localizer = localizer.WithCulture(CultureInfo);
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public Author Author { get; }

        public Navigation Navigation { get; }

        public SiteMetadata Metadata { get; }

        public string Locale { get; }

        public CultureInfo CultureInfo { get; }
        public IStringLocalizer Localizer { get; }

        public string GetString(string key) => Localizer.GetString(key);
    }
}