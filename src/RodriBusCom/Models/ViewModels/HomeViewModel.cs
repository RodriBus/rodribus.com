using Microsoft.Extensions.Localization;
using RodriBusCom.Models.Content;
using RodriBusCom.Resources;

namespace RodriBusCom.Models.ViewModels
{
    public class HomeViewModel : PageViewModel
    {
        public HomeViewModel(Page page, SiteMetadata metadata, Navigation navigation, IStringLocalizer<SharedResource> localizer, string locale) : base(page, metadata, navigation, localizer, locale)
        {
        }
    }
}