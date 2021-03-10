using Microsoft.Extensions.Localization;
using RodriBusCom.Models.Content;
using RodriBusCom.Resources;

namespace RodriBusCom.Models.ViewModels
{
    public class PageViewModel : ViewModelBase
    {
        public Page Page { get; }

        public PageViewModel(Page page, SiteMetadata metadata, Navigation navigation, IStringLocalizer<SharedResource> localizer, string locale) : base(metadata, navigation, localizer, locale)
        {
            Page = page;
        }
    }
}