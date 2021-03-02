using System.Collections.Generic;

namespace RodriBusCom
{
    public static class Locales
    {
        public const string Spanish = "es-ES";
        public const string English = "en-US";
        private const string Default = Spanish;

        private static readonly IDictionary<string, string> Maps =
            new Dictionary<string, string> {
                {Spanish, "" },
                {English, "en" },
            };

        public static string GetPath(string locale)
        {
            if (Maps.TryGetValue(locale, out var path)) return path;
            return Maps[Default];
        }

        public static string GetAlternate(string locale)
            => locale switch {
                Spanish => English,
                _ => Spanish,
            };
    }
}