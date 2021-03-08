using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contentful.Core.Models;

namespace RodriBusCom.Models.Content
{
    public partial class Page
    {
        private const string DefaultPath = "index";

        public string GetLocalizedSlug()
        {
            var slug = Slug.TrimStart('/');
            if (string.IsNullOrEmpty(slug)) slug = DefaultPath;
            var start = Locales.GetPath(Sys.Locale);
            if (!string.IsNullOrEmpty(start)) slug = $"{start}/{slug}";
            return slug;
        }
    }
}