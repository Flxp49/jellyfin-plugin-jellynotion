namespace Jellyfin.Plugin.JellyNotion.Configuration
{
    public class UserConfiguration
    {
        public Guid UserId { get; set; }
        public bool Enable { get; set; }
        public DatabaseInfo DatabaseInfo { get; set; }
        public PropertyInfo LookupProperty { get; set; }
        public PropertyInfo WatchStatusProperty { get; set; }
        public WatchStatuses WatchStatuses { get; set; }
        public bool SyncMovies { get; set; }
        public bool SyncShows { get; set; }
        public string NotionSecret { get; set; }


        public UserConfiguration()
        {
            Enable = false;
            DatabaseInfo = new DatabaseInfo { };
            LookupProperty = new PropertyInfo { };
            WatchStatusProperty = new PropertyInfo { };
            WatchStatuses = new WatchStatuses { Unwatched = "Unwatched", Watching = "Watching", Watched = "Watched" };
            SyncMovies = false;
            SyncShows = false;
            NotionSecret = string.Empty;
        }
    }
    public class DatabaseInfo
    {
        public string ID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class PropertyInfo
    {
        public string ID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
    public class WatchStatuses
    {
        public string Unwatched { get; set; } = string.Empty;
        public string Watched { get; set; } = string.Empty;
        public string Watching { get; set; } = string.Empty;
    }
}
