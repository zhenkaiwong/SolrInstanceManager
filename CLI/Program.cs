// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SolrInstanceManager.Kernel.Extensions;
using SolrInstanceManager.Kernel.Models.Settings;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();
builder.RegisterSimServices();
builder.RegisterSimSettings();
var provider = builder.Build().Services.CreateScope().ServiceProvider;
var settings = provider.GetRequiredService<ISettngs>();
    
Console.WriteLine("Welcome to Solr Instance Manager");
Console.WriteLine(settings.GetDownloadSource());
Console.WriteLine(settings.IsSitecoreEnabled());
Console.WriteLine(settings.IsDefaultSitecore());
