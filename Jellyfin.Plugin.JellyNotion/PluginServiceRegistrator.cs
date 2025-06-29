using Jellyfin.Plugin.JellyNotion.API.Notion;
using Jellyfin.Plugin.JellyNotion.Configuration;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace Jellyfin.Plugin.JellyNotion
{
    public class PluginServiceRegistrator : IPluginServiceRegistrator
    {
        public void RegisterServices(IServiceCollection serviceCollection, IServerApplicationHost applicationHost)
        {
            serviceCollection.AddSingleton<NotionAPI>();
            serviceCollection.AddHttpClient("NotionClient", client =>
            {
                client.BaseAddress = new Uri(Constants.NotionAPIBaseUrl);
                client.DefaultRequestHeaders.Add("Notion-Version", Constants.NotionAPIVersion);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }
    }
}
