using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.JellyNotion.Model
{
    public class QueryDatabaseResponse
    {
        [JsonPropertyName("object")]
        public string NotionObject { get; set; } = null!;

        [JsonPropertyName("results")]
        public Collection<QDBResult> Results { get; } = null!;
    }
    public class QDBResult
    {
        [JsonPropertyName("object")]
        public string NotionObject { get; set; } = null!;

        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("properties")]
        public Dictionary<string, Property> Properties { get; } = null!;

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("in_trash")]
        public bool InTrash { get; set; }
    }

    public class QDBProperty
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;
    }
}
