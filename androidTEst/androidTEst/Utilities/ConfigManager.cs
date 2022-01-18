using System.Configuration;

namespace androidTEst.Utilities
{
    public static class ConfigManager
    {
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
