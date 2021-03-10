using System;
using System.Collections.Generic;
using Contentful.Core.Configuration;
using RodriBusCom.Models.Content;

namespace RodriBusCom.Utils
{
    public class EntityResolver : IContentTypeResolver
    {
        public static Dictionary<string, Type> Types = new Dictionary<string, Type>()
        {
            { Aptitude.ContentTypeId, typeof(Aptitude) },
            { Author.ContentTypeId, typeof(Author) },
            { Contact.ContentTypeId, typeof(Contact) },
            { Education.ContentTypeId, typeof(Education) },
            { Experience.ContentTypeId, typeof(Experience) },
            { IconLink.ContentTypeId, typeof(IconLink) },
            { Knowledge.ContentTypeId, typeof(Knowledge) },
            { Navigation.ContentTypeId, typeof(Navigation) },
            { Page.ContentTypeId, typeof(Page) },
            { Portfolio.ContentTypeId, typeof(Portfolio) },
            { SiteMetadata.ContentTypeId, typeof(SiteMetadata) },
        };

        public Type Resolve(string contentTypeId) => Types.TryGetValue(contentTypeId, out var type) ? type : null;
    }
}