using System.Configuration;

namespace Gmail.Config
{
    public static class Conf
    {
        public static string GetByValue(string key) => ConfigurationManager.AppSettings[key];
    }
}