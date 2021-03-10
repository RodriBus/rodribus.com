using Contentful.Statiq;
using Newtonsoft.Json;

namespace RodriBusCom.Extensions
{
    public static class ContentModelExtensions
    {
        public static Contentful<TContentModel> WithSerializedContent<TContentModel>(this Contentful<TContentModel> module) where TContentModel : class
        {
            module.GetContent = x => JsonConvert.SerializeObject(x, Formatting.Indented);
            return module;
        }
    }
}