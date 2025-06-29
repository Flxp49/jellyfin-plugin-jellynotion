using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Jellyfin.Plugin.JellyNotion.Configuration;
using Jellyfin.Plugin.JellyNotion.Helpers;
using Jellyfin.Plugin.JellyNotion.Model;

namespace Jellyfin.Plugin.JellyNotion.API.Notion
{
    public class NotionAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NotionAPI(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Collection<Result>> GetDatabases(string token)
        {
            var client = _httpClientFactory.CreateClient("NotionClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var payload = new
            {
                filter = new
                {
                    value = "database",
                    property = "object"
                },
                sort = new
                {
                    direction = "descending",
                    timestamp = "last_edited_time"
                }
            };

            var response = await client.PostAsJsonAsync("search", payload).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var res = await JsonSerializer.DeserializeAsync<DatabasesResponse>(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)).ConfigureAwait(false);
            return res == null ? throw new InvalidOperationException("Failed to deserialize databases response from Notion API") : res.Results;
        }

        public async Task<DatabasesResponse> QueryDatabase(string token, string DBID, PropertyInfo lookupProperty, string lookupID)
        {
            var client = _httpClientFactory.CreateClient("NotionClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var payload = new
            {
                filter = new Dictionary<string, string>
                {
                    {
                        "property"  , lookupProperty.ID
                    },
                    {
                        lookupProperty.Type, lookupID
                    }
                }
            };

            var response = await client.PostAsJsonAsync("databases/" + DBID + "/query", payload).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var res = await JsonSerializer.DeserializeAsync<DatabasesResponse>(await response.Content.ReadAsStreamAsync().ConfigureAwait(false)).ConfigureAwait(false);
            return res ?? throw new InvalidOperationException("Failed to deserialize databases response from Notion API");
        }

        public async Task<bool> UpdateWatchStatus(string token, string PGID, PropertyInfo watchStatusProperty, WatchStatuses status)
        {
            var client = _httpClientFactory.CreateClient("NotionClient");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var payload = NotionHelpers.BuildUpdateWatchStatusPayload(watchStatusProperty, status.Unwatched);

            var response = await client.PatchAsJsonAsync("pages/" + PGID, payload).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
