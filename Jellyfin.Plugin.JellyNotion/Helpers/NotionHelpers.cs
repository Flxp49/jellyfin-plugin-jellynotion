
using Jellyfin.Plugin.JellyNotion.Configuration;

namespace Jellyfin.Plugin.JellyNotion.Helpers
{
    public static class NotionHelpers
    {
        public static Object BuildUpdateWatchStatusPayload(PropertyInfo watchStatusProperty, string watchStatus)
        {
            return new
            {
                properties = new Dictionary<string, object>
                {
                    {
                        watchStatusProperty.ID, watchStatusProperty.Type switch
                        {
                            "rich_text" => new
                            {
                                rich_text = new[]
                                {
                                    new
                                    {
                                        text = new { content = watchStatus }
                                    }
                                }
                            },
                            "select" => new
                            {
                                select = new { name = watchStatus }
                            },
                            _ => throw new NotSupportedException($"Unsupported type: {watchStatusProperty.Type}")
                        }
                    }
                }
            };
        }
    }
}
