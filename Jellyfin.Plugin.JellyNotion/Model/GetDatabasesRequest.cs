using System.ComponentModel.DataAnnotations;

namespace Jellyfin.Plugin.JellyNotion.Model
{
    public class GetDatabasesRequest
    {
        [Required]
        public string Token { get; set; } = null!;
    }
}
