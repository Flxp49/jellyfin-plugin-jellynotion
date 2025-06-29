using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.JellyNotion.Model
{
    public class QueryDatabaseRequest
    {
        [Required]
        [JsonPropertyName("token")]
        public string Token { get; set; } = null!;

        [Required]
        [JsonPropertyName("databaseID")]
        public string DBID { get; set; } = null!;
    }
}
