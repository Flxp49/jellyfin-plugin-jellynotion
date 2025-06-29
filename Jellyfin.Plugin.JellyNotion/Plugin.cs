using Jellyfin.Plugin.JellyNotion.Configuration;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.JellyNotion
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer) : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }
        public override string Name => "JellyNotion";
        public override Guid Id => Guid.Parse("47baba5f-debb-4da1-8405-19d48fd0c6cf");
        public override string Description => "Sync your Jellyfin watch status with your Notion Watchlist";

        /// <summary>
        /// Gets the current plugin instance.
        /// </summary>
        public static Plugin? Instance { get; private set; }
        public IEnumerable<PluginPageInfo> GetPages()
        {
            return [
              new PluginPageInfo
                {
                    Name = Name,
                    EmbeddedResourcePath = GetType().Namespace + ".Web.configPage.html"
                }
            ];
        }
    }
}
