using System;
using System.Configuration;

namespace BlogEngine.Models.DataAccess
{
    public class ConfigManager : IConfigManager
    {
        public string GetConfigurationSetting(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }

        public string GetConnectionString(string connectionStringName)
        {
            if (ConfigurationManager.ConnectionStrings[connectionStringName] == null)
            {
                throw new NullReferenceException(string.Format("No connection string found for {0}.", connectionStringName));
            }

            string f = Environment.CurrentDirectory;

            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString.Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}