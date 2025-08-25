using Microsoft.Extensions.Configuration;

namespace SolrInstanceManager.Kernel.Models.Settings;

public class DefaultSettings : ISettngs
{
    private IConfiguration _configuration;
    
    public DefaultSettings(IConfiguration configuration)
    {
       _configuration = configuration; 
    }

    private T GetSettingValue<T>(string key, T defaultValue)
    {
       T? value = _configuration.GetValue<T>(key);
       if (value is null)
       {
           return defaultValue;
       }
       
       return value;
    }
    
    public string GetDownloadSource()
    {
        return GetSettingValue<string>("downloadSource", "https://test2default.com");
    }

    public bool IsSitecoreEnabled()
    {
        return GetSettingValue<bool>("sitecore:enabled", false);
    }

    public bool IsDefaultSitecore()
    {
        return GetSettingValue<bool>("sitecore:default", false);
    }
}