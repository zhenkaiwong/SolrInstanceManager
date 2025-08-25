namespace SolrInstanceManager.Kernel.Models.Settings;

public interface ISettngs
{
    string GetDownloadSource();
    bool IsSitecoreEnabled();
    bool IsDefaultSitecore();
}