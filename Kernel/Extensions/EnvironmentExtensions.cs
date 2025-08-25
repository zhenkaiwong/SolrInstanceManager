using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SolrInstanceManager.Kernel.Models.Settings;

namespace SolrInstanceManager.Kernel.Extensions;

// Each implementation that reference to SolrInstanceManager.Kernel must call these extension methods
public static class EnvironmentExtensions
{
    // Responsible for register DI services
    public static void RegisterSimServices(this HostApplicationBuilder host)
    {
        host.Services.AddSingleton<ISettngs, DefaultSettings>();
    }

    // Responsible for read & load AppSettings.json
    // This method shouldn't be modified unless we have a good reason
    public static void RegisterSimSettings(this HostApplicationBuilder host)
    {
        host.Configuration.AddJsonFile("AppSettings.json");
    }
}