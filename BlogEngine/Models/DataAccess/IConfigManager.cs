namespace BlogEngine.Models.DataAccess
{
    public interface IConfigManager
    {
        string GetConfigurationSetting(string settingName);
        string GetConnectionString(string connectionStringName);
    }
}