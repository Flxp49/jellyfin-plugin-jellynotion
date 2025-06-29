using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.JellyNotion.Configuration
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        public UserConfiguration[] UserConfigs { get; set; }
        public PluginConfiguration()
        {
            UserConfigs = [];
        }
        public UserConfiguration? GetConfigbyGuid(Guid id)
        {
            return UserConfigs.FirstOrDefault(u => u.UserId == id);
        }
    }
}
