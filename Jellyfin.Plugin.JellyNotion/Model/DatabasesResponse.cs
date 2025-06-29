using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.JellyNotion.Model
{
    public class DatabasesResponse
    {
        [JsonPropertyName("object")]
        public string NotionObject { get; set; } = null!;

        [JsonPropertyName("results")]
        public Collection<Result> Results { get; } = null!;

        [JsonPropertyName("next_cursor")]
        public object NextCursor { get; set; } = null!;

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("object")]
        public string NotionObject { get; set; } = null!;

        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;


        [JsonPropertyName("title")]
        public Collection<Title> Title { get; } = null!;

        [JsonPropertyName("properties")]
        public Dictionary<string, Property> Properties { get; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("in_trash")]
        public bool InTrash { get; set; }
    }

    public class Title
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("text")]
        public Text Text { get; set; } = null!;

        [JsonPropertyName("plain_text")]
        public string PlainText { get; set; } = null!;

    }

    public class Text
    {
        [JsonPropertyName("content")]
        public string Content { get; set; } = null!;

        [JsonPropertyName("link")]
        public object Link { get; set; } = null!;
    }

    public class Property
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        // Use object or JsonElement for raw data
        [JsonPropertyName("select")]
        public JsonElement? Select { get; set; }
    }

    public class IMDbID
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;
    }

    public class WatchStatus
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("select")]
        public Select Select { get; set; } = null!;
    }

    public class Select
    {
        [JsonPropertyName("options")]
        public Collection<Option> Options { get; } = null!;
    }

    public class Option
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("color")]
        public string Color { get; set; } = null!;
    }

    public class IDProperty
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;
    }
}
