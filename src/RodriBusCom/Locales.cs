using System.Collections.Generic;

namespace RodriBusCom
{
    public static class Locales
    {
        public const string Spanish = "es-ES";
        public const string English = "en-US";
        private const string Default = "";

        private static readonly IDictionary<string, string> Maps =
            new Dictionary<string, string> {
                {Default, "" },
                {Spanish, "es" },
                {English, "en" },
            };

        public static string GetPath(string locale)
        {
            if (Maps.TryGetValue(locale, out var path)) return path;
            return Maps[default];
        }
    }
}