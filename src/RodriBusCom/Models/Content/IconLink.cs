using System.Collections.Generic;

namespace RodriBusCom.Models.Content
{
    public partial class IconLink
    {
        private static readonly IDictionary<string, string> ClassnameMap =
            new Dictionary<string, string> {
                { "Direct Link", "fa-external-link-square" },
                { "Documentation", "fa-briefcase" },
                { "Github Source Code", "fa-github" },
                { "Slides", "fa-desktop" },
            };

        public string GetIconClassname()
        {
            ClassnameMap.TryGetValue(Type, out var className);
            return className ?? string.Empty;
        }
    }
}